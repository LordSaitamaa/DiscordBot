using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.EventTemplates
{
    public abstract class TemplateBase : ITemplate
    {
        public eEventTemplateType Type { get; set; }
        public string Name { get; set; }
        public long ID { get; set; }
        public string Rolle { get; set; }
        public string Initiator { get; set; }
        public DateTime EventTime { get; set; }


        protected virtual async Task SaveEvent() { }
        private readonly IUnitOfWorkServer _dal;

        public TemplateBase(IUnitOfWorkServer dal)
        {
            _dal = dal;
        }
    }
}
