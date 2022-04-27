using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thirain.Data.Models
{
    public class Event : Entity
    {
        [Required]
        public long ServerID { get; set; }
        public string Initiator { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public int TemplateType { get; set; }
        public ICollection<EventParticipants> EventParticipants { get; set; }
    }
}
