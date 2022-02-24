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
        public readonly IUnitOfWorkServer _dal;
        protected readonly List<string> _channels;
        protected CommandBase(IUnitOfWorkServer dal)
        {
            _dal = dal;
            _channels = FillChannelCommands();
        }

        private List<string> FillChannelCommands()
        {
            List<string> retList = new List<string>();
            retList.Add("merchant");
            retList.Add("raid");

            return retList;
        }
    }
}
