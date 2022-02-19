using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Thirain.Data.TDBContext
{
    public class ThirainDbContextFactory : IDesignTimeDbContextFactory<ThirainDbContext>
    {
        public ThirainDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("dbsettings.json", false, true)
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder()
                .UseNpgsql(config.GetConnectionString("Default"));

            return new ThirainDbContext(optionsBuilder.Options);
        }
    }
}
