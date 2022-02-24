using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class Config : Entity
    {
        public ulong SID { get; set; }
        public ulong CID { get; set; }
        public string Commands { get; set; }
    }
}
