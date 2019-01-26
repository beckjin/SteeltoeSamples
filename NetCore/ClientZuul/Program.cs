using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ClientZuul
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:6002")
            .UseStartup<Startup>();
    }
}
