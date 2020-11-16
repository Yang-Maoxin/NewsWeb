using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NewsApi.Common;
using NewsApi.Dapper;

namespace NewsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                // Policy 名稱 CorsPolicy 是自訂的，可以自己改
                options.AddPolicy("AllowSameDomain", policy =>
                {
                    // 設定允許跨域的來源，有多個的話可以用 `,` 隔開
                    policy.WithOrigins(Configuration.GetSection("AllowCors").Get<List<string>>().ToArray())
                    .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });
            #region 依赖注入
            var builder = new ContainerBuilder();//实例化容器
            //注册所有模块module
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            //获取所有的程序集
            //var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            var assemblys = RuntimeHelper.GetAllAssemblies().ToArray();

            //注册所有继承IDependency接口的类
            builder.RegisterAssemblyTypes().Where(type => typeof(IDependency).IsAssignableFrom(type) && !type.IsAbstract);
            //注册仓储，所有IRepository接口到Repository的映射
            builder.RegisterAssemblyTypes(assemblys).Where(t => t.Name.EndsWith("Repository") && !t.Name.StartsWith("I")).AsImplementedInterfaces();
            //注册服务，所有IApplicationService到ApplicationService的映射
            //builder.RegisterAssemblyTypes(assemblys).Where(t => t.Name.EndsWith("AppService") && !t.Name.StartsWith("I")).AsImplementedInterfaces();
            builder.Populate(services);
            IContainer ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer); //第三方IOC接管 core内置DI容器 
           //return services.BuilderInterceptableServiceProvider(builder => builder.SetDynamicProxyFactory());
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowSameDomain");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
