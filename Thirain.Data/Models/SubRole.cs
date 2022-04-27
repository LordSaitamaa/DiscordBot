using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class SubRole : Entity
    {
        public EventRole Role { get; set; }
        public string Name { get; set; }
        public string EmoteString { get; set; }
    }
}
