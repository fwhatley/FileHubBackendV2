using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FileHubBackendV2
{
    public class Program
    {
        public static void Main(string[] args) // dotnet core is a console app
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
