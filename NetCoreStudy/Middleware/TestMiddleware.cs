using Microsoft.AspNetCore.Http;
using NetCoreStudy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
        //2，创建中间件代理类
        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext,IMyMiddleService midd)
        {
            midd.MyProperty = 118;
            await _next(httpContext);
        }

    }
}
