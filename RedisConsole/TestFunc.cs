using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConsole
{
    public class TestFunc
    {
        public static bool SetSomething()
        {
            string key = "AA";
            int value = 10;

            return new RedisCacheImp().SetCache(key, value);
        }

        public static string GetSomething()
        {
            string key = "A";
            //string value = "this is A's value !";

            return new RedisCacheImp().GetCache<string>(key);
        }

        /// <summary>
        /// 秒杀活动
        /// </summary>
        public static void MiaoShao()
        {
            // SetSomething();

            using (RedisCacheImp service1 = new RedisCacheImp())
            {
                service1.SetCache("AAA", 10);
            }


            // service1.Dispose();

            for (int i = 0; i < 100; i++)
            {
                bool IsGoOn = true;
                Task.Run(() =>
                {
                    using (RedisCacheImp service = new RedisCacheImp())
                    {
                        if (IsGoOn)
                        {
                            long index = service.StringDecrement("AAA");
                            if (index > 0)
                            {
                                Console.WriteLine($"{i.ToString("000")}秒杀成功，秒杀商品索引为{index}");
                            }
                            else
                            {
                                if (IsGoOn)
                                {
                                    IsGoOn = false;
                                }
                                Console.WriteLine($"{i.ToString("000")}秒杀失败，秒杀索引为{index}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{i.ToString("000")}秒杀失败，秒杀停止");
                        }
                    }
                });
            }
            //service.Dispose();
        }

    }
}
