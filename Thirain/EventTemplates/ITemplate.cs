using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.EventTemplates
{
    public enum eEventTemplateType
    {
        Besprechung = 1,
        Raid = 2,
    }

    public interface ITemplate
    {
        public eEventTemplateType Type { get; set; }
        public string Name { get; set; }
        public long ID { get; set; }
        public string Rolle { get; set; }
        public string Initiator { get; set; }
        public DateTime EventTime { get; set; }
    }
}
