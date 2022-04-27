using Microsoft.EntityFrameworkCore;
using Thirain.Data.Models;
using Thirain.Data.TDBContext;
using System.Collections;
using Thirain.Data.Repositories.Templates;

namespace Thirain.Data.DataAccess
{
    public class UnitOfWorkServer : IUnitOfWorkServer
    {
        private readonly IDbContextFactory<ThirainDbContext> _contextFactory;

        private ITemplateRepository _templateRepository;
        public ITemplateRepository TemplateRepository
        {
            get
            {
                if(_templateRepository == null )
                    _templateRepository = new TemplateRepository(_contextFactory);

                return _templateRepository;
            }
        }


        public UnitOfWorkServer(IDbContextFactory<ThirainDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Config>> GetConfigsByNameAsync(string cmdName)
        {
            List<Config> retList = new List<Config>();
            using (var context = _contextFactory.CreateDbContext())
                retList = await context.Config?.Where(x => x.Commands.Contains(cmdName)).ToListAsync<Config>();

            return retList;
        }

        public async Task<Config> GetConfigsByNameAndServerAsync(string cmdName, long serverID)
        {
            Config retConfig = new Config();
            using (var context = _contextFactory.CreateDbContext())
                retConfig = await context.Config.SingleOrDefaultAsync(x => x.Commands.Contains(cmdName) && x.ServerID == serverID);

            return retConfig;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param> Server Id
        /// <param name="cid"></param> Channel Id
        /// <param name="cmdName"></param> Command which should be inserted
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> InsertConfigForCommandAsync(long sid, long cid, string cmdName)
        {
            string retString = string.Empty;
            using (var context = _contextFactory.CreateDbContext())
            {
                var guild = await context.Config.FirstOrDefaultAsync(x => x.ServerID == sid && x.Commands.Equals(cmdName));
                if (guild == null)
                {
                    guild = context.Add(new Config { ServerID = sid, ChannelID = cid, Commands = cmdName }).Entity;
                    retString = $"For the following Command a config has been created: {guild.Commands}";
                }
                else
                {
                    guild.ChannelID = cid;

                    if (!guild.Commands.Equals(cmdName))
                        guild.Commands = cmdName;
                    retString = $"For the following Command the config has been updated: {guild.Commands}";

                }
                context.SaveChanges();
            }
            return retString;
        }

        public async Task<bool> SaveEventAsync(Event eventDto, List<EventRole> roleDto)
        {
            bool success = false;

            return success;
        }

        public async Task<bool> CheckRolePermissionAsync(long eventid, string requestedRoleName, List<long> serverRoles)
        {
            bool permission = false;



            return permission;
        }

        public async Task<bool> EnterEventAsync(long id, string role)
        {
            bool success = false;
            using (var context = _contextFactory.CreateDbContext())
            {

            }
            return success;
        }

        public async Task<List<Event>> GetAllEventsAsync(long serverID)
        {
            List<Event> retEvent = new();


            return retEvent;
        }
    }
}
