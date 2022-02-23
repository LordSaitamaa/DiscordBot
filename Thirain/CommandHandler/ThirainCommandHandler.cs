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
using System.Timers;
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
        private System.Timers.Timer eventTimer;

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

            eventTimer = new System.Timers.Timer(5000);
            eventTimer.Elapsed += async (sender, e) => await MerchantTimerCallback();
            eventTimer.Start();
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

        private async Task MerchantTimerCallback()
        {
            //var ch = _client.GetGuild(942103230517772388);
            //var guilds = Client.Guilds.Count();
            
            var ch = _client.GetGuild(942103230517772388)?.GetChannel(942103230517772391) as IMessageChannel;
            if (ch != null)
            {
                var message = await ch.SendMessageAsync("```Test: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "```");
                var emote = _client.GetGuild(942103230517772388).Emotes;

                var emoji = (GuildEmote) emote.FirstOrDefault(x => x.Name == "lostarkTest");// as GuildEmote;
                var emoteeee = Emote.Parse($"<:{emoji.Name}:{emoji.Id}>");
                //Console.WriteLine(emoji.GetType().ToString());
                //var heartEmoji = new Emoji("\U0001f495");
                await message.AddReactionAsync(emoteeee);

            }
        }

    }
}
