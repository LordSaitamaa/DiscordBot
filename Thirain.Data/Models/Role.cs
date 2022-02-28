using System.ComponentModel.DataAnnotations.Schema;

namespace Thirain.Data.Models
{
    public class Role : Entity
    {
        [ForeignKey("EventID")]
        public long EventID { get; set; }
        public string RoleName { get; set; }
    }
}
