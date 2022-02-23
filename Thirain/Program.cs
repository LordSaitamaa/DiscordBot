using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Discord.Addons.Hosting;
using Microsoft.Extensions.Logging;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Thirain.CommandHandler;
using Thirain.Data.TDBContext;
using Microsoft.EntityFrameworkCore;
using Thirain.Data.DataAccess;
using System.Threading.Tasks;

namespace Thirain
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(x =>
                {
                    var config = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();
                    x.AddConfiguration(config);
                })
                .ConfigureLogging(x =>
                {
                    x.AddConsole();
                    x.SetMinimumLevel(LogLevel.Debug);
                })
                .ConfigureDiscordHost((context, config) =>
                {
                    config.SocketConfig = new DiscordSocketConfig
                    {
                        LogLevel = Discord.LogSeverity.Debug,
                        AlwaysDownloadUsers = false,
                        MessageCacheSize = 200
                    };

                    config.Token = context.Configuration["Token"];
                })
                .UseCommandService((context, config) =>
                {
                    config.CaseSensitiveCommands = false;
                    config.LogLevel = Discord.LogSeverity.Debug;
                    config.DefaultRunMode = Discord.Commands.RunMode.Sync;
                })
                .ConfigureServices((context, services) =>
                {
                    services
                      .AddHostedService<ThirainCommandHandler>()
                      .AddDbContextFactory<ThirainDbContext>(options => options.UseNpgsql(context.Configuration.GetConnectionString("Default")))
                      .AddSingleton<DataAccessLayer>();
                    
                })
                .UseConsoleLifetime();

            var host = builder.Build();

            using(host)
                await host.RunAsync();
        }
    }
}
