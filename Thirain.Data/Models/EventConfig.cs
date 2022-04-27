using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class EventConfig : Entity
    {
        public long ServerID { get; set; }
        public ICollection<EventManagerRoles> EventManagerRoles { get; set; }
    }
}
