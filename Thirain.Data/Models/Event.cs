using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thirain.Data.Models
{
    public class Event : Entity
    {
        [ForeignKey("Template")]
        public long Template { get; set; }
        [Required]
        public long ServerID { get; set; }
        public string Initiator { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        // Postgre mag keine DateTime
        public DateTime Time { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
