using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.CommandHandler
{
    public class ThirainCommandHandler : ThirainCommandService
    {
        private IServiceProvider _provider;
        private readonly CommandService _commandService;
        private readonly IConfiguration _config;
        private readonly DiscordSocketClient _client;

        public ThirainCommandHandler(DiscordSocketClient client, ILogger<ThirainCommandHandler> logger, IServiceProvider provider, CommandService commandService, IConfiguration config, DataAccessLayer dataAccessLayer) 
            : base(client, logger, config, dataAccessLayer)
        {
            _client = client;
            _provider = provider;
            _commandService = commandService;
            _config = config;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
