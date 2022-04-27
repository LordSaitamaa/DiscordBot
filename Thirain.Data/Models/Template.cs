namespace Thirain.Data.Models
{
    public class Template : Entity
    {
        public ICollection<EventRole> EventRoles { get; set; }
        public ICollection<Event> Events { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Inline { get; set; }
        public long ServerID { get; set; }
    }
}
