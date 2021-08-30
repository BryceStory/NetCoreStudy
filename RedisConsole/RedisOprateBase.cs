using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConsole
{
    public abstract class RedisOprateBase : IDisposable
    {
        protected IRedisClient Redis { get; private set; }

        private bool _disposed = false;

        protected RedisOprateBase()
        { 
       // Redis=RedisManager
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
