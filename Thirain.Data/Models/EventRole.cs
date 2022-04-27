using System.ComponentModel.DataAnnotations.Schema;

namespace Thirain.Data.Models
{
    public class EventRole : Entity
    {
        public string RoleName { get; set; }
        public string EmoteString { get; set; }
        public ICollection<SubRole> SubRoles { get; set; }
        
    }
}
