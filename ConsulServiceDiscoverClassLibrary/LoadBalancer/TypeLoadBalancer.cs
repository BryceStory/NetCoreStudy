using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulServiceDiscover.LoadBalancer
{
    //负载均衡算法的单例
    public static class TypeLoadBalancer
    {
        public static ILoadBalancer RandomLoad = new RandomLoadBalancer();
        public static ILoadBalancer RoundRobinLoad = new RoundRobinLoadBalancer(); 

    }
}
