using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace PAF.DAS.WebAPI
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            var baseUrl = Configuration.GetSection("BaseUrl").Value;
            BuildWebHost(args, baseUrl).Run();
        }

        public static IWebHost BuildWebHost(string[] args, string baseUrl) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls(baseUrl)
                .UseStartup<Startup>()
                .Build();
    }
}
