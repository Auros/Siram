using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Siram.Server
{
    public class Program
    {
        private static Initialization _initialization = null!;

        public static Task Main(string[] args)
        {
            (IHostBuilder, Initialization) siramSetup = CreateHostBuilder(args);
            _initialization = siramSetup.Item2;
            using IHost host = siramSetup.Item1.Build();
            return host.RunAsync();
        }

        private static (IHostBuilder, Initialization) CreateHostBuilder(string[] args)
        {
            Initialization initializer = new Initialization();
            IHostBuilder builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    initializer.Configure(services);
                });
            return (builder, initializer);
        }
    }
}