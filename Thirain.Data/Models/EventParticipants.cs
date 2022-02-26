using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class EventParticipants : Entity
    {
        [ForeignKey("EventID")]
        public long EventID { get; set; }
        [ForeignKey("UserID")]
        public long  UserID { get; set; }   
    }
}
