using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Data.DataAccess;

namespace Thirain.Model
{
    public class EmoteCollection
    {
        private static IReadOnlyCollection<GuildEmote> emotes = new List<GuildEmote>();

        public static IReadOnlyCollection<GuildEmote> GetEmotes(IReadOnlyCollection<GuildEmote> guildEmotes)
        {
            if (emotes == null)
                emotes = guildEmotes;

            return emotes;
        }
    }
}
