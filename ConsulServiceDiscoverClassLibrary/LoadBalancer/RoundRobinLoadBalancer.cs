﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulServiceDiscover.LoadBalancer
{
    //轮询负载均衡算法
    public class RoundRobinLoadBalancer : ILoadBalancer
    {
        private readonly object _lock = new object();

        private int _index = 0;


        public string Resolve(IList<string> services)
        {
            lock (_lock)
            {

                if (_index >= services.Count)
                {
                    _index = 0;
                }

                return services[_index++];
            }
        }
    }
}
