using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Dto
{
    public class EventParticipantDto
    {
        public long EventID { get; set; }
        public long UserID { get; set; }
        public int Rolle { get; set; }
        public string UserName { get; set; }
    }
}
