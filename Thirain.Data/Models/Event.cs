using System.ComponentModel.DataAnnotations;

namespace Thirain.Data.Models
{
    public class Event : Entity
    {
        
        [Required]
        public long SID { get; set; }
        public string EventCreator { get; set; }
        public string EventBeschreibung { get; set; }
        public DateTime Time { get; set; }

    }
}
