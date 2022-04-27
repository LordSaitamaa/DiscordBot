using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;
using Thirain.Data.Models;

namespace Thirain.EventTemplates
{
    public class CustomTemplate : TemplateBase
    {

        public override string Name { get; set; }
        protected override List<EventRole> RoleList { get; set; }
        protected override List<GuildEmote> GuildEmoteList { get; set; }
        protected override string TemplateDescription { get; set; }
        protected override int Notification { get; set; }
        public CustomTemplate(SocketCommandContext ctx, IUnitOfWorkServer dal, eEventTemplateType type) : base(ctx, dal, type)
        {
        }

        public override async Task<Embed> BuildEmbedFromTemplate(Event evt, SocketCommandContext ctx)
        {
            DateTime execTime = TimeZoneInfo.ConvertTimeFromUtc(evt.Time, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
            Random rnd = new Random();
            var newEmbed = new EmbedBuilder
            {
                Title = evt.EventName,
                Description = evt.Description,
                Color = Color.DarkBlue,
            };


            return newEmbed.Build();
        }
    }
}
