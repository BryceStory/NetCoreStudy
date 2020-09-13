using System;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDemo();

            Console.ReadLine();
        }

        [Custom(10)]
        public static void TestDemo()
        { 
        
        }
    }
}
