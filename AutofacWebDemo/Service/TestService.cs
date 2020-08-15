using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacWebDemo.Service
{
    public class TestService:ITestService
    {
        public string Get()
        {
            return "Get test";
        }

        public string GetName(string name)
        {
            return $"Getname: Name is {name}";
        }
    }
}
