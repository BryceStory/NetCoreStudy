using ConsulServiceDiscover.LoadBalancer;
using ConsulServiceDiscoverClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsulServiceDiscover.Builder
{
    public interface IServiceBuilder
    {
        //服务生成器
        IServicePrivoder ServicePrivoder { get; set; }
        //服务名称
        string ServiceName { get; set; }
        //uri方案
        string UriScheme { get; set; }
        //你用哪种策略？
        ILoadBalancer LoadBalancer { get; set; }

        Task<Uri> BuilderAsync(string path);
    }
}
