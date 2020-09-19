using System.Collections.Generic;
using System;
using System.Linq;


namespace LambdaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("this is lambda Demo");


            // var a = "Bryce";
            // var age = 13;

            // // () => { Console.WriteLine($"{a}dada{name}"); };
            // Action action0 = () => { Console.WriteLine("wo shi action  wu can shu "); };
            // action0.Invoke();

            List<Student> stuLst = new List<Student>() {
                                 new Student(){
    Id=12,Name="aa",Gender=false},
new Student(){Id=18,Name="bb",Gender=true},
new Student(){Id=22,Name="cc",Gender=true},
new Student(){Id=32,Name="dd",Gender=false },
            };

            // var res = stuLst.Where<Student>(t => t.Gender == true);

            var result = stuLst.BWhere(t => { t.Id > 23});

            Console.ReadLine();
        }
    }
}
