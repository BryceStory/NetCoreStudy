using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutofacWebDemo.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutofacWebDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
    

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        //autofac 注册服务
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>().As<ITestService>();
        }
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    //var basePath2 = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
        //   // var basepath1= Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
        //    var basePath = Environment.CurrentDirectory;
        //    //注册要通过反射创建的组件
        //    //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();

        //    #region 带有接口层的服务注入
        //    //项目引用接口， 服务层和仓储层的bin文件直接使用，实现解耦
        //    var servicesDllFile = Path.Combine(basePath, "Blog.Core.Services.dll");
        //    var repositoryDllFile = Path.Combine(basePath, "Blog.Core.Repository.dll");
        //    if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
        //    {
        //        throw new Exception("Repository.dll和service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。");
        //    }

        //    // AOP 开关，如果想要打开指定的功能，只需要在 appsettigns.json 对应对应 true 就行。
        //    var cacheType = new List<Type>();// 获取 Service.dll 程序集服务，并注册
        //    var assemblysServices = Assembly.LoadFrom(servicesDllFile);
        //    builder.RegisterAssemblyTypes(assemblysServices)
        //                .AsImplementedInterfaces()
        //                .InstancePerDependency()
        //                .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
        //                .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。

        //    // 获取 Repository.dll 程序集服务，并注册
        //    var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
        //    builder.RegisterAssemblyTypes(assemblysRepository)
        //            .AsImplementedInterfaces()
        //            .InstancePerDependency();


        //    #endregion

        //    #region 没有接口层的服务层注入

        //    //因为没有接口层，所以不能实现解耦，只能用 Load 方法。
        //    //注意如果使用没有接口的服务，并想对其使用 AOP 拦截，就必须设置为虚方法
        //    //var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
        //    //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

        //    #endregion

        //    #region 没有接口的单独类 class 注入

        //    //只能注入该类中的虚方法
        //    //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Love)))
        //    //    .EnableClassInterceptors()
        //    //    .InterceptedBy(cacheType.ToArray());

        //    #endregion

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
