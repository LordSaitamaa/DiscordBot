using Discord;
using Microsoft.EntityFrameworkCore;
using Thirain.Data.Models;
using Thirain.Data.TDBContext;

namespace Thirain.Data.DataAccess
{
    public class UnitOfWorkServer : IUnitOfWorkServer
    {
        private readonly IDbContextFactory<ThirainDbContext> _contextFactory;

        public UnitOfWorkServer(IDbContextFactory<ThirainDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Config>> GetConfigsByNameAsync(string cmdName)
        {
            List<Config> retList = new List<Config>();
           using (var context = _contextFactory.CreateDbContext())
                retList = await context.Config.Where(x => x.Commands.Contains(cmdName)).ToListAsync<Config>();

            return retList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param> Server Id
        /// <param name="cid"></param> Channel Id
        /// <param name="cmdName"></param> Command which should be inserted
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> InsertConfigForCommand(long sid, long cid, string cmdName)
        {
            string retString = string.Empty;
            using (var context = _contextFactory.CreateDbContext())
            {
                var guild = await context.Config.FirstOrDefaultAsync(x => x.SID == sid && x.Commands.Equals(cmdName));
                if (guild == null)
                {
                    guild = context.Add(new Config { SID = sid, CID = cid, Commands = cmdName }).Entity;
                    retString = $"Für folgendes Command wurde eine Konfiguration angelegt: {guild.Commands}";
                }
                else
                {
                    guild.CID = cid;

                    if (!guild.Commands.Equals(cmdName))
                        guild.Commands = cmdName;
                    retString = $"Für folgendes Command wurde die Konfiguration angepasst: {guild.Commands}";

                }
                context.SaveChanges();              
            }
            return retString;
        }
    }
}
