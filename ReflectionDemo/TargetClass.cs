using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo
{
    public class TargetClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void GetSometing()
        {
            Console.WriteLine("GetSometing ");
        }
        public void Do(string name)
        {
            Console.WriteLine($"Do name:{name}");
        }

        public void Do(string key ,long id)
        {
            Console.WriteLine($"Do name:{key}");
        }

        public void Do(int age)
        {
            Console.WriteLine($"Do age:{age}");
        }

        public void DoSave(int age)
        {
            Console.WriteLine($"DoSave age:{age}");
        }
    }
}
