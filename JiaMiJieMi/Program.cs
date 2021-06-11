using System;

namespace JiaMiJieMi
{
    class Program
    {
        static void Main(string[] args)
        {
            string strValue = "12345";
            string strValue2 = "12345";
            var res1 = Function.Encypt(strValue);
            var res2 = Function.Encypt(strValue2);

            Console.WriteLine($"{res1}  \n\r {res2}");


            Console.ReadLine();
        }
    }
}
