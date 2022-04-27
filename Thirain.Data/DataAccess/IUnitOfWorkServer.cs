using Thirain.Data.Models;
using Thirain.Data.Repositories.Templates;

namespace Thirain.Data.DataAccess
{
    public interface IUnitOfWorkServer
    {
        public ITemplateRepository TemplateRepository { get; }
        public Task<List<Config>> GetConfigsByNameAsync(string cmdName);
        public Task<Config> GetConfigsByNameAndServerAsync(string cmdName, long serverID);
        public Task<string> InsertConfigForCommandAsync(long sid, long cid, string cmdName);
        public Task<bool> SaveEventAsync(Event eventDto, List<EventRole> eventRoleList);
        public Task<bool> EnterEventAsync(long id, string roleName);
        public Task<bool> CheckRolePermissionAsync(long eventid, string rolename, List<long> serverRoles);
        public Task<List<Event>> GetAllEventsAsync(long serverID);
    }
}
