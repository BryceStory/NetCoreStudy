using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.Services
{
    public class MsgService : IMessageService
    {
        public string Send()
        {
            return "Msg";
        }
    }
}
