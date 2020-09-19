using System;
using static DelegateDemo.Common;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = PeopleType.China;

            switch (type)
            {
                case PeopleType.China:
                    SayHiChina("hah");
                    break;
            }



            Console.ReadLine();
        }
    }
}
