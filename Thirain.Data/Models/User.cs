using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class User : Entity
    {
        [ForeignKey("SID")]
        public long SID { get; set; }
        public string Name { get; set; }
        public int Klasse { get; set; }
    }
}
