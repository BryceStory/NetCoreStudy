using Polly;
using System;


namespace PollyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //polly基本使用步骤分为3步
            //1.定义故障,当发生了定义好的异常 后就会触发策略
            //2.指定策略
            //3.执行策略
            //Policy.HandleInner<ArgumentException>()
            //    .Fallback(() =>
            //    {
            //        Console.WriteLine("polly fallback");
            //    }).Execute(() =>
            //    {
            //        //业务，可跨服务调用 可以和httpclient合用
            //        Console.WriteLine("do something!");
            //        throw new ArgumentException("hello polly");
            //    });

            //关于异常定义
            //1.单个异常
            // Policy.Handle<ArgumentException>();
            //2.带条件异常
            //  Policy.Handle<ArgumentException>(ex => ex.Message == "ttest");
            //3.多个异常
            //  Policy.Handle<ArgumentException>().Or<ArgumentNullException>().Or<ArithmeticException>();
            //4.多个异常带条件
            //  Policy.Handle<ArithmeticException>(ex => ex.Source == "").Or<ArgumentNullException>(ex => ex.ParamName == "");

            //polly故障处理库，有些异常需要处理 ==》服务A访问服务B（请求出错） 
            //业务代码异常是自己的try catch  


            //弹性策略   响应策略：重试，断路器
            //重试3次，不写次数默认1次
            //  Policy.Handle<ArgumentException>().Retry(3);


            //断路器  非常实用的策略，也是必备策略  断路器有3中状态：open  close half-open
            //连续触发指定故障2次后就开启断路器（open）,进入熔断状态 2分钟
            //Policy.Handle<ArgumentException>()
            //    .CircuitBreaker(2, TimeSpan.FromMinutes(2),
            //    (Exception,Span)=> { },  //onBreak ==> open
            //    ()=> { });//onReset ==> close

            //高级断路器
            //如果故障采样时间内，发生故障的比列超过阙值，则发生熔断
            //前提是 在此前提内，通过熔断器的操作数量至少是最小吞吐量
            //Policy.Handle<ArgumentException>()
            //    .AdvancedCircuitBreaker(0.5,  //故障阙值 50%
            //    TimeSpan.FromSeconds(10),  //故障采样时间 10s
            //    30,                        //最小吞吐量，10s内最少执行了30次操作
            //    TimeSpan.FromSeconds(30));   //熔断时间30s
            //half-open，版开启状态，断路器会尝试释放一定比列的 操作，尝试去请求，如果成功则变成close，
            //如果失败则继续熔断30s 断路器打开


            //超时，服务调用没挂，但是超时本身就是一种故障
            //  Policy.Timeout(3);

            //舱壁隔离  通过控制并发数来管理负载，超过12的留20哥并发等待执行，其余的拒绝
            //  Policy.Bulkhead(12,20);

            

            //策略的包装与组合
            //降级策略
            var fallback = Policy.Handle<Exception>().Fallback(() => { Console.WriteLine("polly fallback"); });
            //重试策略
            var retry = Policy.Handle<Exception>().Retry(3, (excption, i) => { Console.WriteLine($"retry count:{i},exception Msg："); });
            //如果重试3次仍发生故障就降级
            //从右到左执行策略
            var policy = Policy.Wrap(fallback, retry);
            policy.Execute(() =>
            {
                Console.WriteLine($"polly begain");
                throw new Exception("test exception");
            });

        }
    }
}
