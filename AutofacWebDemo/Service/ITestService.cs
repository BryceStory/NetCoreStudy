using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacWebDemo.Service
{
    public interface ITestService
    {
        string Get();


        string GetName(string name);

    }
}
