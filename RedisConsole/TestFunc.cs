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


        public static void HashTest()
        {
            var b = new Studend() { StudendId = 100, Name = "bryce", Remark = "sec" };

            var a = new RedisCacheImp();

            //var c = a.SetHashFieldCache<Studend>(typeof(Studend).ToString(), "First", b);

            //var d = a.GetHashFieldCache<Studend>(typeof(Studend).ToString(), "First");

            //Console.WriteLine(d);

            //a.SetHashFieldCache<Studend>("Studend", "A", new Studend() { StudendId = 100, Name = "bryce", Remark = "sec" });
            //a.SetHashFieldCache<Studend>("Studend", "B", new Studend() { StudendId = 100, Name = "bryce", Remark = "sec" });

            //var d = a.GetHashFieldCache<Studend>("Studend", "B");

            //a.cache.HashSet("A1","id","123456");
            //a.cache.HashSet("A1", "name", "cc");
            //a.cache.HashSet("A1", "remark", "test");

            //var d = a.cache.HashGetAll("Studend");
            //a.cache.hash
            //a.cache.HashSet("Ac","cc","11");
            //a.cache.HashSet("Ac", "cc", "22");
            //a.cache.HashSet("Ac", "cc", "33");
            //a.cache.HashSet("Ad",new StackExchange.Redis.HashEntry );

            //a.cache.SetAdd("A", "sda");
            //a.cache.SetAdd("A", "2");
            //a.cache.SetAdd("A", "2");
            //a.cache.set("A", "3");
            a.cache.ListRightPush("C", "321");
            a.cache.ListRightPush("C", "22");
            a.cache.ListRightPush("C", "123");

            a.cache.ListTrim("C",1,2);
            var a1 = a.cache.ListRightPop("C");




            //Console.WriteLine(d);

        }

        public class Studend
        {
            public int StudendId { get; set; }

            public string Name { get; set; }

            public string Remark { get; set; }
        }
    }
}
