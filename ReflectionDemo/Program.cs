using System;
using System.Reflection;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionTest();

            Console.ReadLine();
        }

        public static void ReflectionTest()
        {
             TargetClass targetClass = new TargetClass();


            PropertyInfo[] infos= targetClass.GetType().GetProperties();
            foreach (var item in infos)
            {
                Console.WriteLine($"item name :{item.GetMethod}");
            }

           // Console.WriteLine($"{infos.GetFields().ToString()}   full name : {infos.FullName}");
        }
    }
}
