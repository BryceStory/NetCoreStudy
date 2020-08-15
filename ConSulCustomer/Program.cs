using ConsulServiceDiscover;
using ConsulServiceDiscover.LoadBalancer;
using ConsulServiceDiscoverClassLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConSulCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建consul实例并配置consul注册地址 127.0.0.1：8500
            var serviceProvider = new ConsulServiceProvider(new Uri("http://127.0.0.1:8500/"));

            //需要调用构建的服务类型及负载均衡模式等信息的配置
            var serviceStudent = serviceProvider.CreateServiceBuilder(builder =>
            {
                //消费方需使用的服务名称
                builder.ServiceName = "Student";
                //服务调用的负载均衡模式
                builder.LoadBalancer = TypeLoadBalancer.RoundRobinLoad;
                //服务请求协议 http/https
                builder.UriScheme = Uri.UriSchemeHttp;
            });


            var httpClient = new HttpClient();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"--------------第{i}次请求---------------");

                try
                {
                    //拼接服务调用的具体方法
                    var uri = serviceStudent.BuilderAsync("/api/Default/GetList").Result;
                    Console.WriteLine($"{DateTime.Now.ToString()}--正在调用：{uri}");
                    //发送http的get请求，返回请求服务接口地址后具体的返回信息;此处是调用的student服务的check方法，返回的string值“1”
                    var content = httpClient.GetStringAsync(uri).Result;
                    Console.WriteLine($"调用结果：{content}");



                }
                catch (Exception e)
                {
                    Console.WriteLine($"调用异常信息：{e.GetType()}");

                }
                Task.Delay(1000).Wait();
            }

        }
    }
}
