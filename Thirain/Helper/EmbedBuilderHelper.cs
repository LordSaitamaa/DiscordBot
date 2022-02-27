using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thirain.Model;

namespace Thirain.Helper
{
    public class EmbedBuilderHelper
    {
        public static List<Emoji> NumberEmotes = BuildBasicNumberEmotes();

        private static List<Emoji> BuildBasicNumberEmotes ()
        {
            List<Emoji> emotes = new List<Emoji>();

            emotes.Add(new Emoji("\u0031\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0032\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0033\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0034\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0035\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0036\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0037\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0038\uFE0F\u20E3"));
            emotes.Add(new Emoji("\u0039\uFE0F\u20E3"));

            return emotes;
        }

        public async Task<Embed> BuildMerchantEmbed(MerchantDTO merchant, DateTime currentTime)
        {
            var embed = new EmbedBuilder()
            {
                Title = merchant.Name,
                Description = "Traveling Merchant",
            };

            embed.AddField("Spawntime", currentTime.ToString("f"));
            var stringBuilderLocation = new StringBuilder();
            stringBuilderLocation.AppendLine("Please React with corresponding Emote to signalize the Location.");
            for (int i = 0; i < merchant.Locations.Count; i++)
                stringBuilderLocation.AppendLine($"{NumberEmotes[i]} : [{merchant.Locations[i].Continent}] [{merchant.Locations[i].Area}]({merchant.Locations[i].Hyperlink})");

            embed.AddField("Location", stringBuilderLocation.ToString());


            var stringBuilderItems = new StringBuilder();
            for (int i = 0; i < merchant.Items.Count; i++)
            {
                var item = merchant.Items[i];
                stringBuilderItems.AppendLine($"{item.emote} {item.Itemname}");
            }

            embed.AddField("Items", stringBuilderItems.ToString());

            return embed.Build();
        }

    }
}
