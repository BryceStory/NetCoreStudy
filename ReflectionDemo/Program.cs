using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = ReflectionTest<TargetClass>();

            Console.ReadLine();
        }

        public static PropertyInfo[] ReflectionTest<T>()
        {
            T model = Activator.CreateInstance<T>();

            typeof(T).GetMethod("DoSave").Invoke(model,new object[1] { 123});
            
            //var Constructors = typeof(T).GetConstructors();

            //Console.WriteLine($"Constructors:{Constructors.Count().ToString()}");

            //foreach (var item in typeof(T).GetMethods())
            //{
            //    Console.WriteLine($"GetMethods:{item.Name}");
            //    Console.WriteLine($"GetMethods:{item.GetParameters()}");

            //    foreach (var k in item.GetParameters())
            //    {
            //        Console.WriteLine($"GetMethod:{item.Name} --GetParameters:ParameterType={k.ParameterType},{k.Name}");
            //    }
            //}

            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            return propertyInfos;

        }
    }
}
