using ATCommon.Aspect.Contracts.Interception;
using ATCommon.Caching.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATCommon.Aspect.Caching
{
    public class CacheRemoveAspect : InterceptionAttribute, IAfterInterception
    {
        private readonly Type _cacheType;
        private readonly ICacheManager _cacheManager;
        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;

            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType))
            {
                throw new ArgumentException("Wrong caching type");
            }

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
        }
        public void OnAfter(AfterMethodArgs afterMethodArgs)
        {
            string key = $"{afterMethodArgs.MethodInfo.DeclaringType.FullName}.{afterMethodArgs.MethodInfo.Name}";
            if (_cacheManager.IsExist(key))
            {
                _cacheManager.Remove(key);
            }
        }
    }
}
