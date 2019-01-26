using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientZuul.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;

namespace ClientZuul
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
            // 服务发现客户端
            services.AddDiscoveryClient(Configuration);

            services.AddTransient<DiscoveryHttpMessageHandler>();

            // 指定 BaseService 内使用的 HttpClient 在发送请求前通过 DiscoveryHttpMessageHandler 解析 BaseAddress 为已注册服务的 host:port
            services.AddHttpClient("base-service", c =>
            {
                c.BaseAddress = new Uri(Configuration["services:base-service:url"]);
            })
            .AddHttpMessageHandler<DiscoveryHttpMessageHandler>()
            .AddTypedClient<IBaseService, BaseService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseDiscoveryClient();
        }
    }
}
