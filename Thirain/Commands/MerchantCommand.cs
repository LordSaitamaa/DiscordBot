using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;
using Thirain.Globals;
using Thirain.Helper;

namespace Thirain.Commands
{
    public class MerchantCommand : CommandBase
    {
        public MerchantCommand(IUnitOfWorkServer dal) : base(dal) { }

        [Command("merchant")]
        public async Task ShowMerchantByName(string merchantName)
        {
           
            if(string.IsNullOrEmpty(merchantName))
                await ReplyAsync("No merchant name was entered.");

            string toUpperMerchantName = char.ToUpper(merchantName[0]).ToString() + merchantName.Substring(1);

            var merchant = await MerchantFactory.GetMerchantByName(toUpperMerchantName);

            if (merchant == null)
            {
                await ReplyAsync("Merchant not found.");
                return;
            }

            EmbedBuilderHelper helper = new EmbedBuilderHelper();
            Embed merchantembed = helper.BuildSingleMerchantEmbedAsync(merchant).Result;

            await ReplyAsync(embed: merchantembed);
        }
    }
}
