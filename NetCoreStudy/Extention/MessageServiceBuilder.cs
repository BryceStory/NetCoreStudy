using Microsoft.Extensions.DependencyInjection;
using NetCoreStudy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.Extention
{
    public class MessageServiceBuilder
    {
        public readonly IServiceCollection iServiceCollection;
        public MessageServiceBuilder(IServiceCollection services)
        {
            iServiceCollection = services;
        }

        public void UserEmail()
        {
            iServiceCollection.AddSingleton<IMessageService, EmailService>();
        }

        public void UseMsg()
        {
            iServiceCollection.AddSingleton<IMessageService, MsgService>();
        }
    }
}
