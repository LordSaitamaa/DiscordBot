using Discord.Addons.Hosting;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Thirain.Data.DataAccess;

namespace Thirain.CommandHandler
{
    public abstract class ThirainCommandService : DiscordShardedClientService //DiscordClientService
    {
        public readonly DiscordShardedClient Client;
        public readonly ILogger<DiscordShardedClientService> Logger;
        public readonly IConfiguration Configuration;
        public readonly IUnitOfWorkServer DataAccessLayer;

        public ThirainCommandService(DiscordShardedClient client, ILogger<DiscordShardedClientService> logger, IConfiguration configuration, IUnitOfWorkServer dataAccessLayer)
            : base(client, logger)
        {
            Client = client;
            Logger = logger;
            Configuration = configuration;
            DataAccessLayer = dataAccessLayer;
        }
    }
}
