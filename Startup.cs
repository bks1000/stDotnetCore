using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapp.Models;
using webapp.Utils;

namespace webapp
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
            services.AddApplicationInsightsTelemetry(Configuration);

            //添加系统配置
            services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));

            services.AddMvc();

            services.AddDbContext<MysqlDataContext>();//注意不要注册为单例模式

            #region 添加领域服务

            //应用配置
            services.AddSingleton(typeof(AppConfigurationServices));//单例

            //在这里注册IOC的类
            /*
             *  Transient	每次都重新创建一个实例。                                                                            //services.AddTransien<>();
                Singleton	创建一个单例，以后每次调用的时候都返回该单例对象。                                                   //services.AddSingleton();
                Scoped	在当前作用域内，不管调用多少次，都是一个实例，换了作用域就会再次创建实例，类似于特定作用内的单例。
             */
            //例如：services.AddSingleton<IInstanceGuidService, InstanceGuidService>();
            //      services.AddTransient<INewAlwaysGuidService, NewAlwaysGuidService>();
            //      services.AddScoped<INewGuidService, NewGuidService>();
            //在Controller构造函数中，添加参数，即可。即构造函数注入。



            #endregion

        }

        /// <summary>
        /// 中间件配置
        /// 注意顺序：
        /// 1.异常处理
        /// 2.静态文件服务器
        /// 3.身份验证
        /// 4.MVC
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //异常处理是添加到管道的第一个中间件组件，因此，该组件可捕获在后面的调用中发生的任何异常
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //app.UseAuthentication();//身份验证

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
