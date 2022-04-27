using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.Commands
{
    public class ConfigCommand : CommandBase
    {
 
        public ConfigCommand(IUnitOfWorkServer dal) : base(dal) { }

        [Command("help")]
        [Alias("hilfe", "h")]
        public Task HelpAsync()
        {
            string help = GetHelpCommand();
            return ReplyAsync(help);
        }

        private string GetHelpCommand()
        {
            string help = string.Empty;
            help = "Ich bin die Hilfe";
            return help;
        }

        [Command("confighelp")]
        [RequireUserPermission(Discord.GuildPermission.ManageGuild)]
        public async Task ConfigAsync(string command)
        {
            var u = Context.Message.Author;
            await Discord.UserExtensions.SendMessageAsync(u, command);
        }


        [Command("setchannel")]
        [RequireUserPermission(Discord.GuildPermission.ManageGuild)]
        public async Task ConfigChannelAsync(string command)
        {
            if (!_channels.Contains(command))
            {
                await ReplyAsync("Kein gültiges Command zum konfigurieren.Für weitere Informationen nutzen Sie !confighelp");
                return;
            }          
            
            string reply = _dal.InsertConfigForCommandAsync((long)Context.Guild.Id, (long)Context.Channel.Id, command).Result;
            await ReplyAsync(reply);
        }
    }
}
