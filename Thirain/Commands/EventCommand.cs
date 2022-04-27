using Discord.Commands;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;
using Thirain.EventTemplates;
using System;
using Discord;
using System.Linq;
using Thirain.Data.Models;
using System.Collections.Generic;
using Discord.WebSocket;
using Thirain.Helper;
using Thirain.Globals;
using System.Text.RegularExpressions;

namespace Thirain.Commands
{
    public class EventCommand : CommandBase
    {
        private Emoji checkMark = new Emoji("\u2714");

        public EventCommand(IUnitOfWorkServer dal) : base(dal) { }

        [Command("template", RunMode = RunMode.Async)]
        [RequireContext(ContextType.Guild)]
        public async Task CreateTemplateAsync()
        {
            var guild = Context.Guild;
            var user = Context.User as SocketGuildUser;
            var c = user.CreateDMChannelAsync().Result;

            #region Step 1
            var step1EmbedBuilder = new EmbedBuilder()
            {
                Title = "Template Creation Step 1/4",
                Description = "Please enter a Template name.",
                Color = Color.DarkPurple
            };

            Embed step1Embed = step1EmbedBuilder.Build();

            var step1 = await c.SendMessageAsync(embed: step1Embed);

            var step1Res = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

            if (!step1Res.IsSuccess)
            {
                await c.SendMessageAsync("An error or a timeout occured. Cancel event creation.");
                return;
            }

            var resStep1Message = step1Res.Value!.Content;
            var template = new Template()
            {
                Type = (int)eEventTemplateType.Custom,
                Name = resStep1Message,
            };

            #endregion

            #region Step 2
            var step2EmbedBuilder = new EmbedBuilder()
            {
                Title = "Template Creation Step 2/4",
                Description = "Please enter a Template Description.",
                Color = Color.DarkPurple
            };

            Embed step2Embed = step2EmbedBuilder.Build();

            var step2 = await c.SendMessageAsync(embed: step2Embed);

            var step2Res = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

            if (!step2Res.IsSuccess)
            {
                await c.SendMessageAsync("An error or a timeout occured. Cancel event creation.");
                return;
            }

            var resStep2Message = step2Res.Value!.Content;

            template.Description = resStep2Message;

            #endregion

            #region Step 3
            var step3DescString = $"You can now create up to 15 Roles and per Role you can create 15 Subroles. At least 1 Parent Role is needed. {Environment.NewLine} " +
                                  $"If your role was successfully created the bot will react with an checkmark Emoji to the Message {Environment.NewLine}" +
                                  $"The first [] Brackets indicate the Parent Role every follow Brackets indicates the Sub Role. {Environment.NewLine} " +
                                  $"Please Type the ROLES in the following Format [RoleName:YourServerEmoteName][SubRoleName1:SubRoleEmote1][SubRoleName2:SubRoleEmote2] {Environment.NewLine}" +
                                  $"EXAMPLE: [Warrior:warriorEmote][Lancer:LancerEmote][Paladin:PaladinEmote] ( Dont forget the brackets between two roles) {Environment.NewLine}" +
                                  $"If you dont want to set Emojis u can just leave the brackets like this [Warrior]. {Environment.NewLine}" +
                                  $"As soon as you dont want to add any more you can type '#exit' to stop the Role creation";

            var step3EmbedBuilder = new EmbedBuilder()
            {
                Title = "Template Creation Step 3/4",
                Description = step3DescString,
                Color = Color.DarkPurple
            };

            Embed step3Embed = step3EmbedBuilder.Build();
            var checkmarkEmoji = new Emoji("\U00002705");
            var step3 = await c.SendMessageAsync(embed: step3Embed);

            int maxAmountRoles = 15;
            List<EventRole> tmpRoles = new();

            int i = 0;
            while (i < maxAmountRoles)
            {
                if (i == maxAmountRoles - 1)
                    break;

                var roleStep = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(180));

                if (!roleStep.IsSuccess)
                {
                    await c.SendMessageAsync("An error or a timeout occured. Cancel event creation.");
                    return;
                }
                if (i > 0 && roleStep.Value!.Content.Equals("#exit"))
                {
                    await c.SendMessageAsync("Exit the Role creation.");
                    break;
                }
                var tmpRoleMessage = roleStep.Value!.Content;

                var parsedRoles = await ParseRolesAsync(tmpRoleMessage, guild).ConfigureAwait(false);

                if(parsedRoles == null)
                {
                    await c.SendMessageAsync("Die Rolle wurden im falschen Format eingegeben.");
                    continue;
                }

                tmpRoles.Add(parsedRoles);

                await roleStep.Value.AddReactionAsync(checkmarkEmoji);

                i++;
            }

            template.EventRoles = tmpRoles;
            template.Inline = 1;
            #endregion

            // Now Insert Template IN DB

            var success = await _dal.TemplateRepository.InsertTemplateAsync(template);
            if(success)
                await c.SendMessageAsync("Das Template wurde erfolgreich angelegt.");
            else
                await c.SendMessageAsync("Beim speichern des Templates ist ein Fehler aufgetreten. Bitte wende dich an den Support mit den Schritten zum reproduzieren.");
        }

        private static async Task<EventRole> ParseRolesAsync(string content, SocketGuild guild)
        {
            EventRole role = new();
            role.SubRoles = new List<SubRole>();

            Regex pattern = new(@"(?<=\[).+?(?=\])");
            var results = pattern.Matches(content);

            if (results.Count == 0)
                return null;

            List<string> singleRole = new();
            foreach(Match match in results)
                singleRole.Add(match.Value);

            for(int i = 0; i < singleRole.Count; i++)
            {
                string[] splittedRole = singleRole[i].Split(':');

                if (string.IsNullOrEmpty(splittedRole[0]))
                    continue;

                if (i == 0)
                {
                    var tuple = await GetRoleAndEmoteAsync(guild, splittedRole);
                    role.RoleName = tuple.Item1;
                    role.EmoteString = tuple.Item2;
                }
                else
                {
                    var tuple = await GetRoleAndEmoteAsync(guild, splittedRole);
                    SubRole newRole = new();
                    newRole.Name = tuple.Item1;
                    newRole.EmoteString = tuple.Item2;

                    role.SubRoles.Add(newRole);
                }
            }
            return role;
        }

        private static async Task<(string, string)> GetRoleAndEmoteAsync(SocketGuild guild, string[] content)
        {
            string role = string.Empty;
            string emoteString = string.Empty;

            if (content.Length == 1)
                role = content[0];
            else
            {
                var emotes = await guild.GetEmotesAsync();
                
                var emote =  await emotes.ToAsyncEnumerable().FirstOrDefaultAsync(x => x.Name == content[1]);
                if (emote != null)
                    emoteString = $"<:{content[1]}:{emote.Id}>";

                role = content[0];
            }

            return (role, emoteString);
        }

        [Command("create", RunMode=RunMode.Async)]
        [RequireContext(ContextType.Guild)]
        public async Task CreateEventAsync()
        {
            var guild = Context.Guild;
            var user = Context.User as SocketGuildUser;
            var role = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "Raid-Lead" || x.Name == "Raid-Manager" );

            if (role == null || !user.Roles.Contains(role))
            {
                await ReplyAsync("You dont have the permission to execute the command.");
                return;
            }

            var c = user.CreateDMChannelAsync().Result;

            // Handle Event Name and Description
            DateTime eventTime = DateTime.MinValue;
            string eventDesc = string.Empty;
            string eventName = string.Empty;
            List<EventRole> roleList = new List<EventRole>();
            long tempId = 0;
            ITemplate template = null;
            //List<Role> roleIds = new();
            try
            {
                //Handle input Template
                template = GetUserSelectedTemplate(c).Result;

                if(template == null)
                {
                    await c.SendMessageAsync("No Template was chosen. Use !eventhelp for more Information or create a support request.");
                    return;
                }    


                // tempId = GetUserSelectedTemplate(c, templates).Result;
                // Handle Event Name
                eventName = HandleEventNameAsync(c).Result;
                eventDesc = HandleEventDescriptionAsync(c).Result;
                // Handle Event Start Time Input
                eventTime = DateTimeInputHandle(c).Result;
                //Handle Event Description
                // User should decide which roles are available in the command
               // roleList = HandleEventRolesAsync(c, guild).Result;

                /*tempId = MenuInputHandler(c, templates).Result;



                // Handle Event Roles
                roleList = HandleEventRolesAsync(c, Context).Result;*/

            }
            catch (Exception ex)
            {
                return;
            }

           // var konfig = templates.FirstOrDefault(x => (int)x.Type == tempId);
            try
            {
               // var succes = await _dal.SaveEventAsync(BuildEventSaveDtoAsync((int)konfig.Type, (long)Context.Guild.Id, Context.User.Username, eventName, eventDesc, eventTime).Result, roleList);
                //if(succes)
               //     c.SendMessageAsync("The event was successfully created.");
            } 
            catch(Exception)
            {
                c.SendMessageAsync("An error occured while saving the Event");
            }
        }


        private async Task<ITemplate> GetUserSelectedTemplate(IDMChannel c)
        {
            var menuBuilder = new SelectMenuBuilder()
                .WithPlaceholder("Select a Template")
                .WithCustomId("menu-1")
                .WithMinValues(1)
                .WithMaxValues(1);

            // Description, ID, Name
           menuBuilder.AddOption($"Your Server Custom Template", $"1", $"Custom");
           menuBuilder.AddOption($"Predefined Lost Ark Template", $"2", $"Lost Ark");


            var builder = new ComponentBuilder()
                .WithSelectMenu(menuBuilder);

            var build = builder.Build();
            var menuMsg = await c.SendMessageAsync("Event Creation", components: build);
            var resMenu = await Interactive.NextMessageComponentAsync(x => x.Message.Id == menuMsg.Id, timeout: TimeSpan.FromSeconds(60));

            if (!resMenu.IsSuccess)
                throw new Exception("While processing the Menu Input an Error occured.");

            await resMenu.Value!.DeferAsync();
            var resTempId = resMenu.Value!.Data;

            var tempId = Convert.ToInt64(resTempId.Values.ToArray<string>()[0]);

            return TemplateFactory.BuildTemplateById((eEventTemplateType)tempId, Context, _dal);
        }

        private async Task<DateTime> DateTimeInputHandle(IDMChannel c)
        {
            DateTime retDate = DateTime.MinValue;
            var msgDate = await c.SendMessageAsync("Please enter a Date for the Event execution in following format : dd.mm.yyyy HH:mm");
            // Loop um falschen spam zu verhindern
            int maxTries = 5;
            for (int i = 0; i < maxTries; i++)
            {
                var resDat = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

                try
                {
                    retDate = DateTime.Parse(resDat.Value!.Content.Trim(' '));

                    if (retDate < DateTime.Now)
                    {
                        await c.SendMessageAsync("The event mustn't be in the past");
                        continue;
                    }

                    break;
                }
                catch
                {
                    await c.SendMessageAsync("Not a valid Date-Time. Please enter a Date for the Event execution in following format : dd.mm.yyyy HH:mm");
                }

                if (!resDat.IsSuccess)
                    throw new Exception("An errord occured while processing the input. Try again.");

                if (i == maxTries - 1)
                    throw new Exception("To many false input values");
            }
            return retDate;
        }

        private async Task<string> HandleEventNameAsync(IDMChannel c)
        {
            string eventName = string.Empty;
            int maxTries = 5;
            for (int i = 0; i < maxTries; i++)
            {
                var msgEventName = await c.SendMessageAsync("Please enter a Name for the event. The maximum amount of Characters is 50");
                var resEventName = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

                if (!resEventName.IsSuccess)
                    throw new Exception("While processing the Event Name Data an error occured.");

                eventName = resEventName.Value!.Content;

                // Limit the length of an Event Name
                if (eventName.Length > 50)
                    await c.SendMessageAsync($"The maximum length for the Event Name is 50 characters. Try again.");
                else
                    break;

                if (i == maxTries - 1)
                    throw new Exception("To many false inputs");
            }
            return eventName;
        }

        private async Task<string> HandleEventDescriptionAsync(IDMChannel c)
        {
            string eventDesc = string.Empty;
            int maxTries = 5;
            for (int i = 0; i < maxTries; i++)
            {
                var msgEventDesc = await c.SendMessageAsync("Please enter a Description for the event. The maximum amount of Characters is 200");
                var resEventDesc = await Interactive.NextMessageAsync(x => x.Channel.Id == c.Id, timeout: TimeSpan.FromSeconds(60));

                if (!resEventDesc.IsSuccess)
                    throw new Exception("While processing the Event Description Data an error occured.");

                if(resEventDesc.IsTimeout)
                eventDesc = resEventDesc.Value!.Content;

                if (eventDesc.Length > 200)
                    await c.SendMessageAsync($"The maximum length for the description is 200 characters. Try again.");
                else
                    break;

                if (i == maxTries - 1)
                    throw new Exception("To many false inputs");
            }
            return eventDesc;
        }

        private async Task<Event> BuildEventSaveDtoAsync(int templateType, long sid, string initiator, string eventName, string description, DateTime eventTime)
        {
            var dto = new Event()
            {
                TemplateType = templateType,
                ServerID = sid,
                Initiator = initiator,
                EventName = eventName,
                Description = description,
                Time = eventTime,    
            };
            return dto;
        }


        [Command("showevents")]
        public async Task ShowAllAvailableEventsAsync()
        {

        }

        [Command("templates")]
        public async Task ShowEventTemplatesAsync()
        {

        }

        [Command("enterevent")]
        public async Task EnterEventAsync(long eventid, string role)
        {
            //var rolePermissionCheck = _dal.
            var user = (SocketGuildUser)Context.Guild.Users.FirstOrDefault(x => x.Username == Context.User.Username);
            List<long> userRoles = new ();

            foreach(var userRole in userRoles)
            {
               // userRoles.Add(userRole.I)
            }

            var rolePermissionCheck = _dal.CheckRolePermissionAsync(eventid, role, userRoles);
            //var eventDto = _dal.Get
        }
    }
}
