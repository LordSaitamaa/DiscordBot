using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class Event : Entity
    {
        public long SID { get; set; }
        public string CID { get; set; } 
        public string User { get; set; }
        public string Text { get; set; }

    }
}
