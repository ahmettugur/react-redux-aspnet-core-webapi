using System;

namespace ATCommon.Caching.Contracts
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        /// <summary>
        /// Cache ekleme işlemi yapar
        /// </summary>
        /// <param name="key">Cache key adı</param>
        /// <param name="data">Cache atılacak data</param>
        /// <param name="expireAsMinute">cache duracağı dakika</param>
        void Add(string key, object data, int expireAsMinute);
        /// <summary>
        /// Verilem keye göre Cache'i siler 
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// Verilen keye parametresine göre cahe var mı kontrolü yapar
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsExist(string key);
        /// <summary>
        /// Tüm Cache'i temizler
        /// </summary>
        void Clear();
    }
}
