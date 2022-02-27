using System.ComponentModel.DataAnnotations.Schema;


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
