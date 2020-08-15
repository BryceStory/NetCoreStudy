using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulServiceDiscover.LoadBalancer
{
    public interface ILoadBalancer
    {
        string Resolve(IList<string> services);

    }
}
