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
        public ConfigCommand(DataAccessLayer dal) : base(dal) { }


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
        public async Task ConfigChannelAsync(string command, string command1)
        {
            await ReplyAsync(command + " " + command1);
        }
    }
}
