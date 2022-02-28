using System.ComponentModel.DataAnnotations.Schema;


namespace Thirain.Data.Models
{
    public class EventParticipants : Entity
    {
        [ForeignKey("EventID")]
        public long EventID { get; set; }
        public long UserID { get; set; }
        [ForeignKey("RoleID")]
        public long RoleID { get; set; }
        public string UserName { get; set; }
    }
}
