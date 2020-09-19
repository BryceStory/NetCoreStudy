using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateDemo
{
    public static class Common
    {
        public enum PeopleType
        {
            China,
            American,
            Japan
        }

        public static void SayHiChina(string name)
        {
            Console.WriteLine($"{name},你好呀");
        }

        public static void SayHiAmerican(string name)
        {
            Console.WriteLine($"{name},What's up");
        }

        public static void SayHiJapan(string name)
        {
            Console.WriteLine($"{name},KONIJIWA");
        }

    }
}
