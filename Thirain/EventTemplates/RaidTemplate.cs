using System;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.EventTemplates
{
    public class RaidTemplate : TemplateBase
    {
        public RaidTemplate(IUnitOfWorkServer dal) : base(dal) { }

        protected override async Task SaveEvent()
        {
            throw new NotImplementedException();
        }
    }
}
