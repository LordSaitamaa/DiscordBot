using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Dto
{
    public class EventSaveDto
    {
        public long ServerID { get; set; }
        public string Initiator { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public long TemplateID { get; set; }
    }
}
