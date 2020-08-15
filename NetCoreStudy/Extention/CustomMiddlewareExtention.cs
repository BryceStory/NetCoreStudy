using Microsoft.Extensions.DependencyInjection;
using NetCoreStudy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.Extention
{
    public static partial class CustomMiddlewareExtention
    {
        //3.1 添加依赖服务注册
        public static IServiceCollection AddCustom(this IServiceCollection services)
        {

            return services.AddScoped<IMyMiddleService,MyMiddleService>();
        }
    }
}
