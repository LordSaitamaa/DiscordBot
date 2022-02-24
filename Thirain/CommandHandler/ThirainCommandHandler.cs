using Discord;
using Discord.Addons.Hosting;
using Discord.Addons.Hosting.Util;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;
using Thirain.Model;

namespace Thirain.CommandHandler
{
    public class ThirainCommandHandler : ThirainCommandService
    {
        private IServiceProvider _provider;
        private readonly CommandService _commandService;
        private readonly IConfiguration _config;
        private readonly DiscordShardedClient _client;
        private System.Timers.Timer eventTimer;
        private ulong _serverId;
        public ThirainCommandHandler(DiscordShardedClient client, ILogger<DiscordShardedClientService> logger, IServiceProvider provider, CommandService commandService, IConfiguration config, IUnitOfWorkServer dataAccessLayer) 
            : base(client, logger, config, dataAccessLayer)
        {
            _client = client;
            _provider = provider;
            _commandService = commandService;
            _config = config;
            _serverId = GetServerId();
        }

        private ulong GetServerId()
        {
            var json = JsonConvert.DeserializeObject<ServerDTO>(File.ReadAllText(Path.Combine(new string[] { Directory.GetCurrentDirectory(), "basicEmoteServer.json"})));
            return json.ServerId;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _client.MessageReceived += OnMessageReceived;
            _commandService.CommandExecuted += OnCommandExecuted;

            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);

            await _client.WaitForReadyAsync(stoppingToken);

            eventTimer = new System.Timers.Timer(5000);
            eventTimer.Elapsed += async (sender, e) => await MerchantTimerCallback(EmoteCollection.GetEmotes(_client.GetGuild(_serverId).Emotes));
            eventTimer.Start();
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

            var context = new ShardedCommandContext(_client, message);
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

        private async Task MerchantTimerCallback(IReadOnlyCollection<GuildEmote> guildEmotes)
        {
            //var ch = _client.GetGuild(942103230517772388);
            //var guilds = Client.Guilds.Count();
            var guilds = await DataAccessLayer.GetConfigsByNameAsync("merchant");
            foreach (var guild in guilds)
            {
                var ch = _client.GetGuild(_serverId)?.GetChannel(432) as IMessageChannel;
                if (ch != null)
                {
                    var message = await ch.SendMessageAsync("```Test: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "```");

                    //var emoji = (GuildEmote)emote.FirstOrDefault(x => x.Name == "lostarkTest");// as GuildEmote;
                    //var emoteeee = Emote.Parse($"<:{emoji.Name}:{emoji.Id}>");
                    //await message.AddReactionAsync(emoteeee);

                }
            }
            /*var ch = _client.GetGuild(_serverId)?.GetChannel(432) as IMessageChannel;
            if (ch != null)
            {
                var message = await ch.SendMessageAsync("```Test: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "```");
                var emote = _client.GetGuild(_serverId).Emotes;

                var emoji = (GuildEmote) emote.FirstOrDefault(x => x.Name == "lostarkTest");// as GuildEmote;
                var emoteeee = Emote.Parse($"<:{emoji.Name}:{emoji.Id}>");
                //Console.WriteLine(emoji.GetType().ToString());
                //var heartEmoji = new Emoji("\U0001f495");
                await message.AddReactionAsync(emoteeee);

            }*/
        }

    }
}
