using Microsoft.EntityFrameworkCore;
using Thirain.Data.Models;

namespace Thirain.Data.TDBContext
{
    public class ThirainDbContext : DbContext
    {
        public ThirainDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Config> Config { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
    }
}
