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
using Thirain.Globals;
using Thirain.Helper;
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
        private IReadOnlyCollection<GuildEmote> _guildEmotes;
        private List<MerchantDTO> _merchantDTO;
        private List<DateTime> _allSpawnTimes;
        private DateTime _nextSpawnTime;

        public ThirainCommandHandler(DiscordShardedClient client, ILogger<DiscordShardedClientService> logger, 
                                      IServiceProvider provider, CommandService commandService, IConfiguration config,
                                      IUnitOfWorkServer dataAccessLayer) 
            : base(client, logger, config, dataAccessLayer)
        {
            _client = client;
            _provider = provider;
            _commandService = commandService;
            _config = config;
            
            _nextSpawnTime = DateTime.MinValue;
        }

        private IReadOnlyCollection<GuildEmote> InitGuildEmotes()
        {
            IReadOnlyCollection<GuildEmote> emotes = null;
            try
            {
                 emotes = _client.GetGuild(_serverId).Emotes;
            }
            catch (Exception ex)
            {
                Logger.LogCritical($"Server not found : {ex.Message}");
            }
            return emotes;
        }

        private ulong GetServerId()
        {
            var json = JsonConvert.DeserializeObject<ServerDTO>(File.ReadAllText(Path.Combine(new string[] { Directory.GetCurrentDirectory(), "basicEmoteServer.json"})));
            return json.ServerId;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
            await _client.WaitForReadyAsync(stoppingToken);
            Console.WriteLine("Clients are Ready");

            _client.MessageReceived += OnMessageReceived;
            _commandService.CommandExecuted += OnCommandExecuted;
            
            _serverId = GetServerId();

            _guildEmotes = InitGuildEmotes();
            
            _merchantDTO = MerchantFactory.GetMerchants(_guildEmotes).Result;

            _allSpawnTimes = InitHelper.GetAllSpawntimes();

            eventTimer = new System.Timers.Timer(30000);
            eventTimer.Elapsed += async (sender, e) => await MerchantTimerCallback();
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

        private async Task MerchantTimerCallback()
        {
            eventTimer.Stop();
            var guilds = await DataAccessLayer.GetConfigsByNameAsync("merchant");
            
            var currentMerchants = new List<MerchantDTO>();
            DateTime currentSpawn = DateTime.MinValue;

            DateTime now = DateTime.Now;
            now = now.AddSeconds(-now.Second);

            // TEST 
            //DateTime now = new DateTime(2022, 2, 28, 0, 20, 0);
            if (_nextSpawnTime > now)
            {
                eventTimer.Start();
                return;
            }

            // Berechnet immer die letzte angezeigte Spawntime und setzt die nächste
            // Bsp. Jetzt ist 11:35 dann werden alle Merchants die um 11:30 spawnwn angezeigt und nächste spawntime auf 12:30 gesetzt
            for (int i = 0; i < _allSpawnTimes.Count; i++)
            {
                if (i == _allSpawnTimes.Count - 1)
                {
                    DateTime nextTime = _allSpawnTimes[0];
                    DateTime nextDay = DateTime.Today.AddDays(1);
                    nextDay = nextDay.AddHours(nextTime.Hour).AddMinutes(nextTime.Minute);

                    _nextSpawnTime = nextDay;

                    DateTime currentTime = _allSpawnTimes[_allSpawnTimes.Count - 1];
                    currentSpawn = DateTime.Today.AddHours(currentTime.Hour).AddMinutes(currentTime.Minute);
                    currentMerchants = _merchantDTO.Where(x => x.SpawnTimes.Contains($"{currentTime.Hour}:{currentTime.Minute}")).ToList();  
                    
                }
                else
                {
                    DateTime nextSpawnTime = _allSpawnTimes[i];
                    DateTime nextSpawn = DateTime.Today.AddHours(nextSpawnTime.Hour).AddMinutes(nextSpawnTime.Minute);

                    if (nextSpawn < now)
                        continue;

                    _nextSpawnTime = nextSpawn;

                    DateTime lastSpawn = DateTime.MinValue;

                    if (i > 0)
                    {
                        lastSpawn = _allSpawnTimes[i - 1];
                        currentSpawn = DateTime.Today.AddHours(lastSpawn.Hour).AddMinutes(lastSpawn.Minute);
                        currentMerchants = _merchantDTO.Where(x => x.SpawnTimes.Contains($"{lastSpawn.Hour}:{lastSpawn.Minute}")).ToList();
                    }
                    else
                    {
                        lastSpawn = _allSpawnTimes[_allSpawnTimes.Count - 1];  
                        currentSpawn = DateTime.Today.AddDays(-1).AddHours(lastSpawn.Hour).AddMinutes(lastSpawn.Minute);
                        currentMerchants = _merchantDTO.Where(x => x.SpawnTimes.Contains($"{lastSpawn.Hour}:{lastSpawn.Minute}")).ToList();
                    }
                    break;
                }
            }

            List<Embed> embeds = new List<Embed>();
            EmbedBuilderHelper helper = new EmbedBuilderHelper();

            Dictionary<Embed, IEnumerable<IEmote>> dict = new Dictionary<Embed, IEnumerable<IEmote>>();

            foreach (var merchant in currentMerchants)
            {
                List<Emoji> reactionList = new List<Emoji>();

                for (int i = 0; i <merchant.Locations.Count; i++)
                    reactionList.Add(EmbedBuilderHelper.NumberEmotes[i]);

                dict.Add(await helper.BuildMerchantEmbedTrackingAsync(merchant, currentSpawn), reactionList);
            }

            foreach (var guild in guilds)
            {
                try
                {
                    var ch = _client.GetGuild((ulong)guild.ServerID)?.GetChannel((ulong)guild.ChannelID) as IMessageChannel;

                    if (ch != null)
                    {
                        foreach(var kvPair in dict)
                            await ch.SendMessageAsync(embed: kvPair.Key).ConfigureAwait(false);
                    }
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                    continue;
                }
            }
            eventTimer.Start();
        }

    }
}
