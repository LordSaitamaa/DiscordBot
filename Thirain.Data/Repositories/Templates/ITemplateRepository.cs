using Thirain.Data.Models;
using Thirain.Data.TDBContext;

namespace Thirain.Data.Repositories.Templates
{
    public interface ITemplateRepository
    {
        public Task<IEnumerable<Template>> GetAllServerTemplatesAsync(long serverid);
        public Task<bool> InsertTemplateAsync(Template template);
        public Task<bool> UpdateTemplateAsync(Template template);
        public Task<bool> DeleteTemplateASync(Template template);
        public Task SaveAsync(ThirainDbContext context);
    }
}
