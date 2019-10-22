using ATCommon.Caching.Contracts;
using ATCommon.Utilities;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCommon.Caching.Memcached
{
    public class MemcachedManager : ICacheManager
    {
        private MemcachedClientConfiguration config;
        private MemcachedClient client;

        public MemcachedManager()
        {
            string MemcachedUrl = AppSettingsHelper.GetAppSettings("MemcachedUrl");

            if (string.IsNullOrEmpty(MemcachedUrl))
            {
                throw new Exception("appsettings.json > AppSettings > \"MemcachedUrl\": \"127.0.0.1:11211\" bulunamadı.");
            }

            config = new MemcachedClientConfiguration(new LoggerFactory(), new MemcachedClientOptions());
            config.AddServer(MemcachedUrl);
            config.Protocol = MemcachedProtocol.Binary;
            client = new MemcachedClient(new LoggerFactory(), config);
        }

        public void Add(string key, object data, int expireAsMinute)
        {
            var newDate = DateTime.Now.AddMinutes(expireAsMinute);
            var expireTimeSpan = newDate.Subtract(DateTime.Now);
            client.Store(StoreMode.Set, key, JsonConvert.SerializeObject(data), expireTimeSpan);
        }

        public void Clear()
        {
            client.FlushAll();
        }

        public T Get<T>(string key)
        {
            var cacheObject = client.Get(key);
            if (cacheObject == null)
            {
                cacheObject = "";
            }
            if (cacheObject.ToString() == "[]" || cacheObject.ToString() == "{}")
            {
                cacheObject = "";
            }

            var val = JsonConvert.DeserializeObject<T>(cacheObject.ToString());
            return val;
        }

        public bool IsExist(string key)
        {
            return client.Get(key) != null;
        }

        public void Remove(string key)
        {
            client.Remove(key);
        }

        //public void RemoveByPattern(string pattern)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
