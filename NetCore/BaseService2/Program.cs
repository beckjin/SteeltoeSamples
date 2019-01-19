﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BaseService2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5002")
                .UseStartup<Startup>();
    }
}
