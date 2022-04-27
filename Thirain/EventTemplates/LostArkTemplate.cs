using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;
using Thirain.Data.Models;

namespace Thirain.EventTemplates
{
    public class LostArkTemplate : TemplateBase
    {
        protected override List<EventRole> RoleList { get; set; }
        protected override List<GuildEmote> GuildEmoteList { get ; set; }
        protected override string TemplateDescription { get; set; }
        protected override int Notification { get; set; }
        public override string Name { get; set; } = "Lost Ark";

        public LostArkTemplate(SocketCommandContext ctx, IUnitOfWorkServer dal, eEventTemplateType type) : base(ctx, dal, type)
        {
        }

        public override async Task<Embed> BuildEmbedFromTemplate(Event evt, SocketCommandContext ctx)
        {
            var embedBuilder = new EmbedBuilder()
            {
                Title = "Test"
            };
            return embedBuilder.Build();
        }
    }
}
