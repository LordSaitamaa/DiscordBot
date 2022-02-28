using Thirain.Data.Models;
using Thirain.Data.Dto;

namespace Thirain.Data.DataAccess
{
    public interface IUnitOfWorkServer
    {
        public Task<List<Config>> GetConfigsByNameAsync(string cmdName);
        public Task<List<Template>> GetAllTemplates();
        public Task<string> InsertConfigForCommand(long sid, long cid, string cmdName);
        public Task<bool> SaveEventAsync(EventSaveDto eventDto, List<RoleDto> eventRoleList);
    }
}
