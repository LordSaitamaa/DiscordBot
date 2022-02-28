using Discord.Commands;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;
using Thirain.EventTemplates;
using System;
using Discord;
using Thirain.Data.Dto;
using System.Linq;
using Thirain.Data.Models;
using System.Collections.Generic;

namespace Thirain.Commands
{
    public class EventCommand : CommandBase
    {
        public EventCommand(IUnitOfWorkServer dal) : base(dal) { }

        [Command("newevent")]
        public async Task CreateEventAsync(int eventTyp)
        {
            var template = GetInstanceOfTemplate((eEventTemplateType)eventTyp);
            var c = Context.User.CreateDMChannelAsync().Result;

            var menuBuilder = new SelectMenuBuilder()
                .WithPlaceholder("Select an Template")
                .WithCustomId("menu-1")
                .WithMinValues(1)
                .WithMaxValues(1);

            var templates = _dal.GetAllTemplates().Result;

            foreach(var temp in templates)
                menuBuilder.AddOption($"{temp.TemplateName}", $"{temp.Id}", $"{temp.TemplateDescription}");
            
            var builder = new ComponentBuilder()
                .WithSelectMenu(menuBuilder);

            var build = builder.Build();
            var menuMsg = await c.SendMessageAsync("Event Creation", components: build);
            var resMenu = await Interactive.NextMessageComponentAsync(x => x.Message.Id == menuMsg.Id, timeout: TimeSpan.FromSeconds(60));

            if(!resMenu.IsSuccess)
            {
                await SendEventCancellation(c, string.Empty);
                return;
            }

            await resMenu.Value!.DeferAsync();
            var resTempId = resMenu.Value!.Data;

            if(resTempId.Values.Count == 0)
            {
                await SendEventCancellation(c, "Failed to extract the Template ID.");
                return;
            }

            var tempId = Convert.ToInt64(resTempId.Values.ToArray<string>()[0]);

            var msgDate = await c.SendMessageAsync("Please enter a Date for the Event execution in following format : dd.mm.yyyy HH:mm");
            DateTime eventTime = DateTime.MinValue;

            // Loop um falschen spam zu verhindern
            int maxTries = 5;
            for (int i = 0; i < maxTries; i++)
            {
                var resDat = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

                try
                {
                    eventTime = DateTime.Parse(resDat.Value!.Content.Trim(' '));

                    if(eventTime < DateTime.Now)
                    {
                        await SendEventCancellation(c, "The event mustn't be in the past");
                        return;
                    }
                    break;
                }
                catch
                {
                    await c.SendMessageAsync("Not a valid Date-Time. Please enter a Date for the Event execution in following format : dd.mm.yyyy HH:mm");
                }

                if (!resMenu.IsSuccess)
                {
                    await SendEventCancellation(c, string.Empty); ;
                    return;
                }

                if(i == 4)
                {
                    await SendEventCancellation(c, "To many false input values");
                    return;
                }
            }

            var msgEventName = await c.SendMessageAsync("Please enter a Name for the event");
            var resEventName = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

            if (!resEventName.IsSuccess)
            {
                await SendEventCancellation(c, string.Empty); ;
                return;
            }

            string eventName = resEventName.Value!.Content;

            var msgEventDesc= await c.SendMessageAsync("Please enter a Description for the event");
            var resEventDesc = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

            if (!resEventDesc.IsSuccess)
            {
                await SendEventCancellation(c, string.Empty); ;
                return;
            }

            string eventDesc = resEventDesc.Value!.Content;

            var msgEventRoles = await c.SendMessageAsync("Please enter all available Roles for the event in the following Format: role1,role2,role3 ");
            var resEventRoles = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

            if (!resEventRoles.IsSuccess)
            {
                await SendEventCancellation(c, string.Empty); ;
                return;
            }

            string eventRoles = resEventRoles.Value!.Content;
            string[] rolesSplitted = null;
            try
            {
                rolesSplitted = eventRoles.Split(',');

                if (rolesSplitted == null)
                    throw new Exception();
            }
            catch (Exception)
            {
                await SendEventCancellation(c, "Can't extract the roles out of the text."); ;
                return;
            }

            var konfig = templates.FirstOrDefault(x => x.Id == tempId);
            var succes = await _dal.SaveEventAsync(BuildEventSaveDtoAsync(konfig, (long)Context.Guild.Id, Context.User.Username, eventName, eventDesc, eventTime).Result,
                                                   BuildEventRoleDto(rolesSplitted).Result);
        }

        private async Task<EventSaveDto> BuildEventSaveDtoAsync(Template template, long sid, string initiator, string eventName, string description, DateTime eventTime)
        {
            var dto = new EventSaveDto()
            {
                ServerID = sid,
                Initiator = initiator,
                EventName = eventName,
                Description = description,
                Time = eventTime,    
                TemplateID = template.Id,
            };
            return dto;
        }

        private async Task<List<RoleDto>> BuildEventRoleDto(string[] roleSplitted)
        {
            List<RoleDto> roleList = new List<RoleDto>();
            foreach(var role in roleSplitted)
                roleList.Add(new RoleDto() { RoleName = role});
            return roleList;
        }

        private async Task SendEventCancellation(IDMChannel dm, string reason)
        {
            dm.SendMessageAsync($"Cancel Event Creation. {reason}");
        }

        [Command("showevents")]
        public async Task ShowAllAvailableEventsAsync()
        {

        }

        [Command("templates")]
        public async Task ShowEventTemplates()
        {

        }

        private ITemplate GetInstanceOfTemplate(eEventTemplateType type)
        {
            switch (type)
            {
                case eEventTemplateType.Raid: return new RaidTemplate(_dal);
                case eEventTemplateType.Besprechung: return new EventTemplate(_dal);
                default: return new EventTemplate(_dal);
            }
        }
    }
}
