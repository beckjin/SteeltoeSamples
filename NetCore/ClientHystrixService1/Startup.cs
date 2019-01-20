using ClientHystrixService1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using System;

namespace ClientHystrixService1
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

            // Add Steeltoe Hystrix Command
            services.AddHystrixCommand<BaseServiceCommand>("base-service", Configuration);

            // Add Hystrix Metrics to container
            services.AddHystrixMetricsStream(Configuration);

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
            // Add Steeltoe Discovery Client service
            app.UseDiscoveryClient();
            // Start Hystrix metrics stream service
            app.UseHystrixMetricsStream();
        }
    }
}
