using ConsoleAppFramework;
using Gaspra.Signing;
using Microsoft.Extensions.Configuration;
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
                .RunConsoleAppFrameworkAsync<EncryptionService>(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices((host, services) =>
            {
                services
                    .RegisterSecretSigningCertificateOption("My", "CurrentUser", "CN=Gaspra.Signing")
                    .RegisterSigningServices();
            });
    }
}
