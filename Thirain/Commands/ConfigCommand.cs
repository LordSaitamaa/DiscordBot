using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.Commands
{
    public class ConfigCommand : CommandBase
    {
 
        public ConfigCommand(IUnitOfWorkServer dal) 
            : base(dal) 
        {
        }



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
        public async Task ConfigChannelAsync(string guild, string channel, string command)
        {
            if (!_channels.Contains(command))
            {
                await ReplyAsync("Kein gültiges Command zum konfigurieren.Für weitere Informationen nutzen Sie !confighelp");
                return;
            }
          
            long cid = 0;
            long sid = 0;
            try
            {
                sid = Convert.ToInt64(guild);
                cid = Convert.ToInt64(channel);
            } 
            catch (Exception)
            {
                await ReplyAsync("Beim konfigurieren ist ein Fehler aufgetreten. Für weitere Informationen nutzen Sie !confighelp");
                return;
            }

            
            string reply = _dal.InsertConfigForCommand(sid, cid, command).Result;
            await ReplyAsync(reply);
        }
    }
}
