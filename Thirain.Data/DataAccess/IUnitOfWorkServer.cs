using Thirain.Data.Models;

namespace Thirain.Data.DataAccess
{
    public interface IUnitOfWorkServer
    {
        public Task<List<Config>> GetConfigsByNameAsync(string cmdName);

        public Task<string> InsertConfigForCommand(long sid, long cid, string cmdName);
    }
}
