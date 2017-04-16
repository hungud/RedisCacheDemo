using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class RedisHelper
    {
        private IDatabase redis_database { get; set; }

        public RedisHelper(IDatabase RedisDatabase)
        {
            redis_database = RedisDatabase;
        }

        public bool Add<T>(string key, T value, DateTimeOffset expiresAt) where T : class
        {
            var serializedObject = JsonConvert.SerializeObject(value);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);

            return redis_database.StringSet(key, serializedObject, expiration);
        }

        public T Get<T>(string key) where T : class
        {
            var serializedObject = redis_database.StringGet(key);

            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public bool Remove(string key)
        {
            return redis_database.KeyDelete(key);
        }

        public bool Exists(string key)
        {
            return redis_database.KeyExists(key);
        }
    }
}
