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

            // typeof(T).GetMethod("DoSave").Invoke(model,new object[] { 123});
            //当方法重载时，GetMethod可以先指定方法参数类型
            // typeof(T).GetMethod("Do",new Type[] { typeof(string),typeof(long)}).Invoke(model, new object[] {"hahhah", 123 });

            {
                //静态方法的调用 可以传递实例 也可以不传递实例（model）
                //  typeof(T).GetMethod("StaticFun").Invoke(model, new object[] { 123 });
                // typeof(T).GetMethod("StaticFun").Invoke(null,new object[] { 123 });
            }

            {
                //私有方法的调用 使用BindingFlags
                //typeof(T).GetMethod("PrivateFun",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(model, new object[] { 123 });
            }

            {
                //泛型方法的调用 
               // typeof(T).GetMethod("GenricClass").MakeGenericMethod(new Type[] { typeof(string), typeof(int) }).Invoke(model, new object[] {"test", 123 });
            }

            {
                ////属性操作
                //Type type = typeof(T);


                //foreach (var item in type.GetProperties())
                //{
                //    if (item.Name.Equals("Id"))
                //    {
                //        item.SetValue(model, 123);
                //    }
                //    else if (item.Name.Equals("Name"))
                //    {
                //        item.SetValue(model, "test");
                //    }

                //    Console.WriteLine($"{type.Name}.{item.Name}={item.GetValue(model)}");
                //}
            }

            {
                //字段操作
                Type type = typeof(T);


                foreach (var item in type.GetFields())
                {
                    if (item.Name.Equals("Id"))
                    {
                        item.SetValue(model, 123);
                    }
                    else if (item.Name.Equals("Desc"))
                    {
                        item.SetValue(model, "test");
                    }

                    Console.WriteLine($"{type.Name}.{item.Name}={item.GetValue(model)}");
                }
            }

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
