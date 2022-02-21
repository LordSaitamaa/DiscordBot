using Discord.Addons.Hosting;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.CommandHandler
{
    public abstract class ThirainCommandService : DiscordClientService
    {
        public readonly DiscordSocketClient Client;
        public readonly ILogger<DiscordClientService> Logger;
        public readonly IConfiguration Configuration;
        public readonly DataAccessLayer DataAccessLayer;

        public ThirainCommandService(DiscordSocketClient client, ILogger<DiscordClientService> logger, IConfiguration configuration, DataAccessLayer dataAccessLayer)
            : base(client, logger)
        {
            Client = client;
            Logger = logger;
            Configuration = configuration;
            DataAccessLayer = dataAccessLayer;
        }
    }
}
