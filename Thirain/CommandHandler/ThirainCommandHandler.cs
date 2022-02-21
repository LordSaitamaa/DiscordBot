using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public ThirainCommandHandler(DiscordSocketClient client, ILogger<DiscordClientService> logger, IServiceProvider provider, CommandService commandService, IConfiguration config, DataAccessLayer dataAccessLayer) 
            : base(client, logger, config, dataAccessLayer)
        {
            _client = client;
            _provider = provider;
            _commandService = commandService;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _client.MessageReceived += OnMessageReceived;
            _commandService.CommandExecuted += OnCommandExecuted;
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }

        private async Task OnMessageReceived(SocketMessage rawMessage)
        {
            if (!(rawMessage is SocketUserMessage message))
                return;
            if (message.Source != MessageSource.User)
                return;

            var argpos = 0;
            if (!message.HasCharPrefix('!', ref argpos))
                return;

            var context = new SocketCommandContext(_client, message);
            await _commandService.ExecuteAsync(context, argpos, _provider);
        }
        private async Task OnCommandExecuted(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
        {
            if (!commandInfo.IsSpecified)
                return;

            if (result.IsSuccess)
                return;

            await commandContext.Channel.SendMessageAsync($"error: {result.ErrorReason} ");
        }

    }
}
