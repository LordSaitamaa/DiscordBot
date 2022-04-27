using Microsoft.EntityFrameworkCore;
using Thirain.Data.Models;

namespace Thirain.Data.TDBContext
{
    public class ThirainDbContext : DbContext
    {
        public ThirainDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Config> Config { get; set; }
        public DbSet<EventConfig> EventConfig { get; set; }
        public DbSet<EventManagerRoles> EventManagerRoles { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
        public DbSet<EventRole> EventRoles { get; set; }
        public DbSet<SubRole> SubRoles { get; set; }
        public DbSet<Template> Templates { get; set; }
    }
}
