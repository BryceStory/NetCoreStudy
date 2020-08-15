using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreStudy.Extention;

namespace NetCoreStudy
{
    //启动类的多环境配置，需修改Program.cs的 webBuilder.UseStartup(Assembly.GetExecutingAssembly().FullName);
    public class StartupDemo
    {
        public void ConfigureDemoServices(IServiceCollection services)
        {
            //服务容器
            services.AddControllersWithViews();
            //添加自定义服务封装
            services.AddMessage(buider => buider.UseMsg());
            // services.AddCustom();
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //多环境配置
        //根据launchSetting下的ASPNETCORE_ENVIRONMENT 的值来匹配加载的选项，只需要修改ConfigureDemoServices 中间的demo字样即可，此为默认约定
        //如果没有找到配置的方法则找默认方法ConfigureServices
        public void ConfigureDemoServices(IServiceCollection services)
        {
            //服务容器
            services.AddControllersWithViews();
            //添加自定义服务封装
            services.AddMessage(buider => buider.UseMsg());
            // services.AddCustom();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        //服务注册
        public void ConfigureServices(IServiceCollection services)
        {
            //服务容器
            services.AddControllersWithViews();
            //添加自定义服务封装
            services.AddMessage(buider => buider.UseMsg());
           // services.AddCustom();
        }

        //原理和ConfigureServices配置一致，只是将名字加在Configure后面
        public void ConfigureDemo(IApplicationBuilder app, IWebHostEnvironment env)
        { 
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //中间件注册
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("middleware 1 begin \r\n");
            //    await next();
            //    await context.Response.WriteAsync("middleware 1 end \r\n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("middleware 2 begin \r\n");
            //    await next();
            //    await context.Response.WriteAsync("middleware 2 end \r\n");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("hello run \r\n");

            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UserCustom();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
