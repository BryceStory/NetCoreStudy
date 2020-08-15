using ConsulServiceDiscover.Builder;
using ConsulServiceDiscoverClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulServiceDiscover
{
    public static class ConsulPrivoderExtension
    {
        //进行服务配置
        public static IServiceBuilder CreateServiceBuilder(this IServicePrivoder serviceProvider,Action<IServiceBuilder> config)
        {
            var builder = new ServiceBuilder(serviceProvider);
            config(builder);

            return builder;
        }

    }
}
