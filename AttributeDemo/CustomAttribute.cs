using System;
using System.Collections.Generic;
using System.Text;

namespace AttributeDemo
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]  //允许多个特性修饰  允许特性修饰所有类型（all）
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(int id)
        { 
        
        }
    }
}
