using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class EventManagerRoles : Entity
    {
        public EventConfig Config { get; set; }
        public long RoleID { get; set; }
    }
}
