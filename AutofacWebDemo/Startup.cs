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

        //autofac ע�����
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>().As<ITestService>();
        }
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    //var basePath2 = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
        //   // var basepath1= Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
        //    var basePath = Environment.CurrentDirectory;
        //    //ע��Ҫͨ�����䴴�������
        //    //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();

        //    #region ���нӿڲ�ķ���ע��
        //    //��Ŀ���ýӿڣ� �����Ͳִ����bin�ļ�ֱ��ʹ�ã�ʵ�ֽ���
        //    var servicesDllFile = Path.Combine(basePath, "Blog.Core.Services.dll");
        //    var repositoryDllFile = Path.Combine(basePath, "Blog.Core.Repository.dll");
        //    if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
        //    {
        //        throw new Exception("Repository.dll��service.dll ��ʧ����Ϊ��Ŀ�����ˣ�������Ҫ��F6���룬��F5���У����� bin �ļ��У���������");
        //    }

        //    // AOP ���أ������Ҫ��ָ���Ĺ��ܣ�ֻ��Ҫ�� appsettigns.json ��Ӧ��Ӧ true ���С�
        //    var cacheType = new List<Type>();// ��ȡ Service.dll ���򼯷��񣬲�ע��
        //    var assemblysServices = Assembly.LoadFrom(servicesDllFile);
        //    builder.RegisterAssemblyTypes(assemblysServices)
        //                .AsImplementedInterfaces()
        //                .InstancePerDependency()
        //                .EnableInterfaceInterceptors()//����Autofac.Extras.DynamicProxy;
        //                .InterceptedBy(cacheType.ToArray());//����������������б�����ע�ᡣ

        //    // ��ȡ Repository.dll ���򼯷��񣬲�ע��
        //    var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
        //    builder.RegisterAssemblyTypes(assemblysRepository)
        //            .AsImplementedInterfaces()
        //            .InstancePerDependency();


        //    #endregion

        //    #region û�нӿڲ�ķ����ע��

        //    //��Ϊû�нӿڲ㣬���Բ���ʵ�ֽ��ֻ���� Load ������
        //    //ע�����ʹ��û�нӿڵķ��񣬲������ʹ�� AOP ���أ��ͱ�������Ϊ�鷽��
        //    //var assemblysServicesNoInterfaces = Assembly.Load("Blog.Core.Services");
        //    //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

        //    #endregion

        //    #region û�нӿڵĵ����� class ע��

        //    //ֻ��ע������е��鷽��
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
