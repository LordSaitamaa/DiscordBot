using Discord;

namespace Thirain.Model
{
    public enum eItemCategory
    {
        Rapport = 1,
        Card = 2,
        Ingredient = 3,
    }

    public class MerchantItem
    {
        public GuildEmote emote { get; set; }
        public string Itemname { get; set; }
        public eItemCategory category { get; set; }
    }
}
