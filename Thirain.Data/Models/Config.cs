namespace Thirain.Data.Models
{
    public class Config : Entity
    {
        public long SID { get; set; }
        public long CID { get; set; }
        public string Commands { get; set; }
    }
}
