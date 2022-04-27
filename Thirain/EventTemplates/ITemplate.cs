using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;
using Thirain.Data.Models;

namespace Thirain.EventTemplates
{
    public enum eEventTemplateType
    {
        Custom = 1,
        LostArk = 2,
    }

    public interface ITemplate
    {
        public eEventTemplateType Type { get; set; }
        public abstract Task<Embed> BuildEmbedFromTemplate(Event evt, SocketCommandContext ctx);
    }
}
