using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.TDBContext;

namespace Thirain.Data.DataAccess
{
    public class DataAccessLayer
    {
        private readonly IDbContextFactory<ThirainDbContext> _contextFactory;

        public DataAccessLayer(IDbContextFactory<ThirainDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
