using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCacheDemo
{
    public class ClassTest2
    {
        public void TestExpire()
        {
            var RedisConnection = RedisConnectionFactory.GetConnection();
            var db = RedisConnection.GetDatabase();
            db.StringSet("ABC", 1, TimeSpan.FromMinutes(1));

            var a = new Microsoft.Extensions.Caching.Redis.RedisCache();
            


        }
    }
}
