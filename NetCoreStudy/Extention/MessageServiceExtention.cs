using NetCoreStudy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreStudy.Extention
{
    public static class MessageServiceExtention
    {
        public static void AddMessage(this IServiceCollection service, Action<MessageServiceBuilder> action)
        {
            // service.AddSingleton<IMessageService, EmailService>();
            var builder = new MessageServiceBuilder(service);
            action(builder);
        }

    }
}
