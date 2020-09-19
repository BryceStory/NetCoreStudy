using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaDemo
{
    public static class Common
    {
        public static List<Student> BWhere(this List<Student> Res, Func<Student, bool> func)
        {
            var lst = new List<Student>();
            foreach (var item in Res)
            {
                if (func.Invoke(item))
                {
                    lst.Add(item);
                }
            }
            return lst;
        }
    }
}