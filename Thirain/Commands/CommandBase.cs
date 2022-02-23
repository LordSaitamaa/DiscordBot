using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thirain.CommandHandler;
using Thirain.Data.DataAccess;

namespace Thirain.Commands
{
    public abstract class CommandBase : ModuleBase<SocketCommandContext>
    {
        public readonly DataAccessLayer _dal;
        protected CommandBase(DataAccessLayer dal)
        {
            _dal = dal;
        }
    }
}
