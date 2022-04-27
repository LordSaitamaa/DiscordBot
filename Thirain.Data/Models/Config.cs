namespace Thirain.Data.Models
{
    public class Config : Entity
    {
        public long ServerID { get; set; }
        public long ChannelID { get; set; }
        public string Commands { get; set; }
    }
}
