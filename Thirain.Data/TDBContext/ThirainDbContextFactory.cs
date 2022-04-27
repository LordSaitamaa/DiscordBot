using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
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
            .AddJsonFile("appsettings.json", false, true)
            .Build();
            
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseNpgsql(config.GetConnectionString("Default"));

            return new ThirainDbContext(optionsBuilder.Options);
        }
    }
}
