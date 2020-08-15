using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsulServiceDiscoverClassLibrary
{
    public interface IServicePrivoder
    {
        Task<IList<string>> GetServiceAsync(string serviceName);

    }
}
