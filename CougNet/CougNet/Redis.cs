using System;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CougNet
{
    public class Redis
    {

        public T GetObject<T>(IDistributedCache distributedCache, string key) where T : class
        {
            try
            {
                string resp = distributedCache.GetString(key);

                if (string.IsNullOrEmpty(resp))
                    return null;
                else
                    return JsonConvert.DeserializeObject<T>(resp);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void StoreObject(IDistributedCache distributedCache, string key, object obj)
        {
            var options = new DistributedCacheEntryOptions();
            //   .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
            //  .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            distributedCache.SetString(key, JsonConvert.SerializeObject(obj));
        }
    }
}
