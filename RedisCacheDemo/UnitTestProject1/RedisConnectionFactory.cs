using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class RedisConnectionFactory
    {

        private static readonly Lazy<ConnectionMultiplexer> Connection;

        static RedisConnectionFactory()
        {
            var connectionString = "localhost";

            var options = ConfigurationOptions.Parse(connectionString);

            Connection = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(options)
            );
        }

        public static ConnectionMultiplexer GetConnection() => Connection.Value;
    }
}
