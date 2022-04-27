using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;
using Thirain.Data.Models;

namespace Thirain.EventTemplates
{
    public abstract class TemplateBase : ITemplate
    {
        public eEventTemplateType Type { get; set; }
        protected string Description { get; set; }
        public abstract string Name { get; set; }
        protected abstract List<EventRole> RoleList { get; set; }
        protected abstract List<GuildEmote> GuildEmoteList { get; set; }
        protected abstract string TemplateDescription { get; set; }
        protected abstract int Notification { get; set; }

        protected SocketCommandContext _ctx;
        protected IUnitOfWorkServer _dal;

        protected TemplateBase(SocketCommandContext ctx, IUnitOfWorkServer dal, eEventTemplateType type)
        {
            Type = type;
            _ctx = ctx;
            _dal = dal;
        }

        public virtual Task<Embed> BuildEmbedFromTemplate(Event evt,  SocketCommandContext ctx) { throw new NotImplementedException(); }
    }
}
