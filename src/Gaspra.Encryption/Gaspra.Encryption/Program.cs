using Gaspra.Signing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Gaspra.Encryption
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args)
                .RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((host, config) =>
            {
                host
                    .HostingEnvironment.EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                config
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json");
            })
            .ConfigureServices((host, services) =>
            {
                services
                    .RegisterSigningServices()
                    .AddHostedService<EncryptionService>();
            });
    }
}
