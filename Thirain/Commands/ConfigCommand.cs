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
        [Alias("hilfe")]
        public Task HelpAsync()
        {
            return ReplyAsync("HALLOOOOO");
        }
    }
}
