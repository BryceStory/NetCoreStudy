using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreStudy.Extention;

namespace NetCoreStudy
{
    //������Ķ໷�����ã����޸�Program.cs�� webBuilder.UseStartup(Assembly.GetExecutingAssembly().FullName);
    public class StartupDemo
    {
        public void ConfigureDemoServices(IServiceCollection services)
        {
            //��������
            services.AddControllersWithViews();
            //����Զ�������װ
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

        //�໷������
        //����launchSetting�µ�ASPNETCORE_ENVIRONMENT ��ֵ��ƥ����ص�ѡ�ֻ��Ҫ�޸�ConfigureDemoServices �м��demo�������ɣ���ΪĬ��Լ��
        //���û���ҵ����õķ�������Ĭ�Ϸ���ConfigureServices
        public void ConfigureDemoServices(IServiceCollection services)
        {
            //��������
            services.AddControllersWithViews();
            //����Զ�������װ
            services.AddMessage(buider => buider.UseMsg());
            // services.AddCustom();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        //����ע��
        public void ConfigureServices(IServiceCollection services)
        {
            //��������
            services.AddControllersWithViews();
            //����Զ�������װ
            services.AddMessage(buider => buider.UseMsg());
           // services.AddCustom();
        }

        //ԭ���ConfigureServices����һ�£�ֻ�ǽ����ּ���Configure����
        public void ConfigureDemo(IApplicationBuilder app, IWebHostEnvironment env)
        { 
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //�м��ע��
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
