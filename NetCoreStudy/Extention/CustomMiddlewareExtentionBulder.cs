using Microsoft.AspNetCore.Builder;
using NetCoreStudy.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.Extention
{
    public static partial class CustomMiddlewareExtentionBulder
    {
        ////3.2 创建中间件扩展类
        public static IApplicationBuilder UserCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMiddleware>();
        }
    }
}
