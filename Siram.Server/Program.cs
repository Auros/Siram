using Serilog.Core;
using System.Threading.Tasks;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Siram.Server
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            (IHostBuilder, Initialization) siramSetup = CreateHostBuilder(args);
            using IHost host = siramSetup.Item1.Build();
            return host.RunAsync();
        }

        private static (IHostBuilder, Initialization) CreateHostBuilder(string[] args)
        {
            Initialization initializer = new Initialization();
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices((env, services) =>
            {
                initializer.Configure(services);
                Logger logger = initializer.Logging(env.HostingEnvironment.ContentRootPath);
                services.AddSingleton<ILoggerFactory>(sp => new SerilogLoggerFactory(logger, true));
            });
            return (builder, initializer);
        }
    }
}