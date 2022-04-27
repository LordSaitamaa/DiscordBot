using System.ComponentModel.DataAnnotations.Schema;


namespace Thirain.Data.Models
{
    public class EventParticipants : Entity
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public Event Event { get; set; }
        public SubRole SubRole { get; set; }
    }
}
