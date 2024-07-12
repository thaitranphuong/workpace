using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace API.Services
{
    public class CacheService : ICacheService
    {
        private ObjectCache _memoryCache = MemoryCache.Default;

        public T GetData<T>(string key)
        {
            try
            {
                T item = (T)_memoryCache.Get(key);
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object RemoveData(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    var result = _memoryCache.Remove(key);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {

            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _memoryCache.Set(key, value, expirationTime);
                    return true;
                }
                else
                    return false;
                    
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
