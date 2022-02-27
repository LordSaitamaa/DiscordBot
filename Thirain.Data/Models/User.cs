using System.ComponentModel.DataAnnotations.Schema;


namespace Thirain.Data.Models
{
    public class User : Entity
    {
        [ForeignKey("SID")]
        public long SID { get; set; }
        public string Name { get; set; }
        public int Klasse { get; set; }
    }
}
