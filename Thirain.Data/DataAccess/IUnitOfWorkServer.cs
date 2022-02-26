using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.Models;

namespace Thirain.Data.DataAccess
{
    public interface IUnitOfWorkServer
    {
        public Task<List<Config>> GetConfigsByNameAsync(string cmdName);

        public Task<string> InsertConfigForCommand(long sid, long cid, string cmdName);
    }
}
