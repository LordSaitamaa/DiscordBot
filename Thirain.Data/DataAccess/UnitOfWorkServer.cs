using Microsoft.EntityFrameworkCore;
using Thirain.Data.Models;
using Thirain.Data.TDBContext;
using Thirain.Data.Dto;
using System.Collections;

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

        public async Task<List<Template>> GetAllTemplates()
        {
            List<Template> templates = new List<Template>();
            using (var context = _contextFactory.CreateDbContext())
                templates = await context.Templates.ToListAsync<Template>();

            return templates;
        }

        public async Task<bool> SaveEventAsync(EventSaveDto eventDto, List<RoleDto> roleDto)
        {
            bool success = false;

            using(var context = _contextFactory.CreateDbContext())
            {
                var eventNew = context.Event.Add(new Event()
                {
                    Template = eventDto.TemplateID,
                    ServerID = eventDto.ServerID,
                    Initiator = eventDto.Initiator,
                    EventName = eventDto.EventName,
                    Description = eventDto.Description,
                    Time = TimeZoneInfo.ConvertTimeToUtc(eventDto.Time, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")),
                }).Entity;

                eventNew.Roles = new List<Role>();
                foreach (var role in roleDto)
                {
                    var eventRole = new Role() { RoleName = role.RoleName };
                    eventNew.Roles.Add(eventRole);
                }
                /* foreach(var role in roleDto)
                 {
                     var eventRole = context.Roles.Add(new Role()
                     {
                         EventID = eventNew.Id,
                         RoleName = role.RoleName
                     });
                 }*/
                context.SaveChanges();
            }
            return success;
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
    }
}
