using Discord.Commands;
using Thirain.Data.DataAccess;
using Thirain.EventTemplates;

namespace Thirain.Helper
{
    public class TemplateFactory
    {
        public static ITemplate BuildTemplateById(eEventTemplateType id, SocketCommandContext ctx, IUnitOfWorkServer dal)
        {
            switch(id)
            {
                case eEventTemplateType.Custom: return new CustomTemplate(ctx, dal, id); break;
                case eEventTemplateType.LostArk: return new LostArkTemplate(ctx, dal, id); break;
                default: return null;
            }
        }
    }
}
