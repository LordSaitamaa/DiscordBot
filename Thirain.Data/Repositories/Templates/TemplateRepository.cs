using Microsoft.EntityFrameworkCore;
using Thirain.Data.Models;
using Thirain.Data.TDBContext;

namespace Thirain.Data.Repositories.Templates
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly IDbContextFactory<ThirainDbContext>  _dbContextFactory; 

        public TemplateRepository(IDbContextFactory<ThirainDbContext> DbContextFactory)
        {
            _dbContextFactory = DbContextFactory;
        }

        public async Task<IEnumerable<Template>> GetAllServerTemplatesAsync(long serverid)
        {
            IEnumerable<Template> templates = null;
            using(var context = _dbContextFactory.CreateDbContext())
            {
                templates = (IEnumerable<Template>?)context.Templates.ToAsyncEnumerable();
            }
            return templates;
        }

        public async Task<bool> InsertTemplateAsync(Template template)
        {
            bool success = false;
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var templ = await context.Templates.AddAsync(template);
                if(templ != null)
                {
                    success = true;
                    await context.SaveChangesAsync();
                }
            }

            return success;
        }

        public Task<bool> UpdateTemplateAsync(Template template)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteTemplateASync(Template template)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(ThirainDbContext context)
        {
            context.SaveChanges();
        }
    }
}
