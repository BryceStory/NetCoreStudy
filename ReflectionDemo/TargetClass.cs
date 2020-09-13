using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo
{
    public class TargetClass
    {
        public int Id { get; set; }
        //属性
        public string Name { get; set; }   //有get set访问器的叫属性  没有的叫字段
        //字段
        public string Desc;
        public string Desc2;

        public void GenricClass<K, S>(K t, S s)
        {
            Console.WriteLine($"GenricClass K:{typeof(K).ToString()},S  {typeof(S).ToString()} ");
        }

        public void GetSometing()
        {
            Console.WriteLine("GetSometing ");
        }
        public void Do(string name)
        {
            Console.WriteLine($"Do name:{name}");
        }

        public void Do(string key, long id)
        {
            Console.WriteLine($"Do name:string {key}  long :{id}");
        }

        public void Do(int age)
        {
            Console.WriteLine($"Do age:{age}");
        }

        public void DoSave(int age)
        {
            Console.WriteLine($"DoSave age:{age}");
        }

        public static void StaticFun(int age)
        {
            Console.WriteLine($"static StaticFun age:{age}");
        }

        private void PrivateFun(int age)
        {
            Console.WriteLine($"static StaticFun age:{age}");
        }
    }
}
