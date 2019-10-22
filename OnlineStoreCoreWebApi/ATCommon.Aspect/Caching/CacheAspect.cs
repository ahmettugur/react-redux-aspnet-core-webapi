using ATCommon.Aspect.Contracts.Interception;
using ATCommon.Caching.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATCommon.Aspect.Caching
{
    public class CacheAspect : InterceptionAttribute, IBeforeInterception, IAfterInterception
    {
        private readonly Type _cacheType;
        private readonly Type _returnType;
        private readonly int _expireAsMinute;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, Type returnType, int expireAsMinute = 60)
        {
            _cacheType = cacheType;

            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType))
            {
                throw new ArgumentException("Wrong caching type");
            }
            _returnType = returnType;
            _expireAsMinute = expireAsMinute;
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

        }
        public object OnBefore(BeforeMethodArgs beforeMethodArgs)
        {
            string key = $"{beforeMethodArgs.MethodInfo.DeclaringType.FullName}.{beforeMethodArgs.MethodInfo.Name}";

            object data = null;
            if (_cacheManager.IsExist(key))
            {
                var cacheData = _cacheManager.Get<object>(key);
                if (cacheData == null)
                {
                    _cacheManager.Remove(key);
                    return null;
                }
                data = JsonConvert.DeserializeObject(cacheData.ToString(), _returnType);

            }

            return data;
        }

        public void OnAfter(AfterMethodArgs afterMethodArgs)
        {
            string key = $"{afterMethodArgs.MethodInfo.DeclaringType.FullName}.{afterMethodArgs.MethodInfo.Name}";
            if (!_cacheManager.IsExist(key))
            {
                if (afterMethodArgs.Value != null)
                {
                    if (afterMethodArgs.Value.ToString() != "[]" && afterMethodArgs.Value.ToString() != "[]" && !string.IsNullOrEmpty(afterMethodArgs.Value.ToString()))
                    {
                        _cacheManager.Add(key, afterMethodArgs.Value, _expireAsMinute);
                    }
                }

            }
        }
    }
}
