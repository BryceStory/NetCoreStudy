using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFunc.SetSomething();

            // Console.WriteLine(TestFunc.GetSomething());
            //new RedisCacheImp().AppendString();

            TestFunc.MiaoShao();

            Console.ReadLine();
        }
    }
}
