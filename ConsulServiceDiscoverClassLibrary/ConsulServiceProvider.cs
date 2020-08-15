using Consul;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsulServiceDiscoverClassLibrary
{
    public class ConsulServiceProvider : IServicePrivoder
    {
        private readonly ConsulClient _consulClient;


        public ConsulServiceProvider(Uri uri)
        {
            //创建consul实例并配置consul注册地址 127.0.0.1：8500
            _consulClient = new ConsulClient(consulConfig=> {
                consulConfig.Address = uri;
            });
        }

        /// <summary>
        /// 获取该服务可用地址列表 地址+端口
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public async Task<IList<string>> GetServiceAsync(string serviceName)
        {
            //获取当前consul已经注册的服务，最后的passingonly参数为true：证明只返回健康检查通过的服务l
            var queryResult = await _consulClient.Health.Service(serviceName, "", true);
            var result = new List<string>();
            foreach (var service in queryResult.Response)
            {
                result.Add(service.Service.Address+":"+service.Service.Port);
            }

            return result;
        }
    }
}
