using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.EventTemplates
{
    public class EventTemplate : TemplateBase
    {
        public EventTemplate(IUnitOfWorkServer dal) : base(dal) { }
        protected override async Task SaveEvent()
        {
            throw new NotImplementedException();
        }
    }
}
