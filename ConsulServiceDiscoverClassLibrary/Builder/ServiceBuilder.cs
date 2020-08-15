using ConsulServiceDiscover.LoadBalancer;
using ConsulServiceDiscoverClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsulServiceDiscover.Builder
{
    public class ServiceBuilder : IServiceBuilder
    {
        public IServicePrivoder ServicePrivoder { get; set; }
        public string ServiceName { get; set; }
        public string UriScheme { get; set; }
        public ILoadBalancer LoadBalancer { get; set; }

        public ServiceBuilder(IServicePrivoder servicePrivoder)
        {
            ServicePrivoder = servicePrivoder;
        }

        /// <summary>
        /// 拼接服务调用的具体方法
        /// </summary>
        /// <param name="path">除了ip 端口外的具体地址</param>
        /// <returns></returns>
        public async Task<Uri> BuilderAsync(string path)
        {
            //获取该服务可用地址列表 地址+端口
            var serviceList = await ServicePrivoder.GetServiceAsync(ServiceName);
            //根据选择的负载均衡牧师来构建服务，返回目标具体使用的服务地址
            var service = LoadBalancer.Resolve(serviceList);
            //拼接http+服务调用地址+端口
            var baseUri = new Uri($"{UriScheme}://{service}");
            //拼接服务调用的具体方法
            var uri = new Uri(baseUri, path);

            return uri;
        }
    }
}
