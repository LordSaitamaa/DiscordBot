using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thirain.Model;

namespace Thirain.Globals
{
    public static class MerchantFactory
    {

        private static List<MerchantDTO> _merchants;
        private static IReadOnlyCollection<GuildEmote> _guildEmotes;
        public static List<MerchantDTO> GetMerchants(IReadOnlyCollection<GuildEmote> guildEmotes)
        {
            if(_merchants == null)
                _merchants = InitMerchants(guildEmotes);

            return _merchants;
        }

        private static List<MerchantDTO> InitMerchants(IReadOnlyCollection<GuildEmote> guildEmotes)
        {
            List<MerchantDTO> merchants = new List<MerchantDTO>();
            _guildEmotes = guildEmotes;

            // Init all Merchants seperately to get a better overview about the single merchants
            InitBen(merchants);
            InitLucas(merchants);
            InitMalone(merchants);
            InitMorris(merchants);
            InitMorris(merchants);
            InitBurt(merchants);
            InitOliver(merchants);
            InitMac(merchants);
            InitNox(merchants);
            InitPeter(merchants);
            InitJeffrey(merchants);
            InitAricer(merchants);
            InitRaitir(merchants);
            InitDorella(merchants);
            InitRayni(merchants);

            return merchants;
        }

        private static void InitBen(List<MerchantDTO> merchants)
        {
            var ben = new MerchantDTO() { Name = "Ben", Items = new List<MerchantItem>(), Locations = new List<string>()};

            // Init Locations
            ben.Locations = new List<string>() { "Ankumo Mountain", "Loghill", "Rethramis Border"};
            ben.Items.Add(new MerchantItem() { Itemname = "Fancier Bouquet", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Prideholme Potato", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Rehtramis Holy Water", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Surprise Chest", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Prideholme Neria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            ben.Items.Add(new MerchantItem() { Itemname = "Varut Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            ben.Items.Add(new MerchantItem() { Itemname = "Siera Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
        }

        private static void InitLucas(List<MerchantDTO> merchants)
        {
            var lucas = new MerchantDTO() { Name = "Lucas", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            lucas.Locations = new List<string>() { "Saland Hill", "Ozhorn Hill" };
            lucas.Items.Add(new MerchantItem() { Itemname = "Yudia Spellbook", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            lucas.Items.Add(new MerchantItem() { Itemname = "Yudia Natural Salt", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            lucas.Items.Add(new MerchantItem() { Itemname = "Sky Reflection Oil", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            lucas.Items.Add(new MerchantItem() { Itemname = "Giant Worm Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            lucas.Items.Add(new MerchantItem() { Itemname = "Morina Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            lucas.Items.Add(new MerchantItem() { Itemname = "Thunder Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
        }

        private static void InitMalone(List<MerchantDTO> merchants)
        {
            var malone = new MerchantDTO() { Name = "Malone", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            malone.Locations = new List<string>() { "Mount Zagoras", "Lakebar", "Medrick Monastery", "Bilbrin Forest" };
            malone.Items.Add(new MerchantItem() { Itemname = "Black Rose", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Lakebar Tomato Juice", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Stalwart Cage", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Chain War Chronicles", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Berhart Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            malone.Items.Add(new MerchantItem() { Itemname = "Cadogan Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            malone.Items.Add(new MerchantItem() { Itemname = "Cassleford Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            malone.Items.Add(new MerchantItem() { Itemname = "Hairplant", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
        }

        private static void InitMorris(List<MerchantDTO> merchants)
        {
            var morris = new MerchantDTO() { Name = "Morris", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            morris.Locations = new List<string>() { "Dyorika Plains", "Sunbright Hill", "Flowring Orchard" };
            morris.Items.Add(new MerchantItem() { Itemname = "Azenaporium Brooch", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Dyroika Straw Hat", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Model of Luterra's Sword", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Chain War Chronicles", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Brinewt Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Morpheo Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Meehan Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Thunder Wings Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Dry-aged Meat", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });

        }

        private static void InitBurt(List<MerchantDTO> merchants)
        {
            var burt = new MerchantDTO() { Name = "Burt", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            burt.Locations = new List<string>() { "Blackrose Chapel", "Leyar Terrace", "Borea's Domain", "Croconys Seashore" };
            burt.Items.Add(new MerchantItem() { Itemname = "Azenaporium Brooch", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Dyroika Straw Hat", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Model of Luterra's Sword", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Chain War Chronicles", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Seria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            burt.Items.Add(new MerchantItem() { Itemname = "Nox Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            burt.Items.Add(new MerchantItem() { Itemname = "Thunder Wings Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            burt.Items.Add(new MerchantItem() { Itemname = "Hot Chocolate Coffee", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
        
        }

        private static void InitOliver(List<MerchantDTO> merchants)
        {
            var oliver = new MerchantDTO() { Name = "Oliver", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            oliver.Locations = new List<string>() { "Seaswept Woods", "Sweetwater Forest", "Skyreach Steppe", "Forest of Giants" };
            oliver.Items.Add(new MerchantItem() { Itemname = "Mokoko Carrot", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Oversize Ladybug Doll", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Round Glass Piece", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Shy Wind FLower Pollen", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Egg of Creation Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            oliver.Items.Add(new MerchantItem() { Itemname = "Eolh Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            oliver.Items.Add(new MerchantItem() { Itemname = "Mokamoka Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
        }

        private static void InitMac(List<MerchantDTO> merchants)
        {
            var mac = new MerchantDTO() { Name = "Mac", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            mac.Locations = new List<string>() { "Delphi Township", "Rattan Hill", "Melody Forest", "Twilight Mists" };
            mac.Items.Add(new MerchantItem() { Itemname = "Tournament Entrance Stamp", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            mac.Items.Add(new MerchantItem() { Itemname = "Angler's Fishing Pole", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            mac.Items.Add(new MerchantItem() { Itemname = "Sir Valleylead Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            mac.Items.Add(new MerchantItem() { Itemname = "Sir Druden Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            mac.Items.Add(new MerchantItem() { Itemname = "Madam Moonscent Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            mac.Items.Add(new MerchantItem() { Itemname = "Wei Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
        }

        private static void InitNox(List<MerchantDTO> merchants)
        {
            var nox = new MerchantDTO() { Name = "Nox", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            nox.Locations = new List<string>() { "Arid Path", "Scraplands", "Nebel Horn", "Windbringer Hill", "Tottrich", "Rizza Falls" };
            nox.Items.Add(new MerchantItem() { Itemname = "Fine Gramophone", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            nox.Items.Add(new MerchantItem() { Itemname = "Energy X7 Capsule", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            nox.Items.Add(new MerchantItem() { Itemname = "Bergstrom Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            nox.Items.Add(new MerchantItem() { Itemname = "Stern Neria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            nox.Items.Add(new MerchantItem() { Itemname = "Krause Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            nox.Items.Add(new MerchantItem() { Itemname = "Adrenaline-boosting fluid", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });

        }

        private static void InitPeter(List<MerchantDTO> merchants)
        {
            var peter = new MerchantDTO() { Name = "Peter", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            peter.Locations = new List<string>() { "Port Krona", "Parna Forest", "Fesnar Highland", "Vernese Forest", "Balankar Mountain" };
            peter.Items.Add(new MerchantItem() { Itemname = "Exquisite Music Box", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Goblin Yam", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Magick Cloth", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Magick Crystal", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Queen's Knights Application", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Vern's Founding Coin", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Payla Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            peter.Items.Add(new MerchantItem() { Itemname = "Gideon Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            peter.Items.Add(new MerchantItem() { Itemname = "Thar Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });

        }

        private static void InitJeffrey(List<MerchantDTO> merchants)
        {
            var jeffrey = new MerchantDTO() { Name = "Jeffrey", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            jeffrey.Locations = new List<string>() { "Frozen Sea", "Bitterwind Hill", "Iceblood Plateau", "Lake Eternity", "Icewing Heights" };
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Shimmering Essence", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Siriu's Holy Book", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Javern Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Sian Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Madnick Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Sapphire Sardine", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
        }

        private static void InitAricer(List<MerchantDTO> merchants)
        {
            var aricer = new MerchantDTO() { Name = "Aricer", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            aricer.Locations = new List<string>() { "Lake Shiverwave", "Glass Lotus Lake", "Breezesome Brae", "Xeneela Ruins", "Elzowin's Shade" };
            aricer.Items.Add(new MerchantItem() { Itemname = "Danube's Earrings", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Elemental's Feather", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Soundstone of Dawn", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Sylvain Queens' Blessing", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Alifer Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            aricer.Items.Add(new MerchantItem() { Itemname = "Lenora Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            aricer.Items.Add(new MerchantItem() { Itemname = "Gnosis Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            aricer.Items.Add(new MerchantItem() { Itemname = "Pit-A-Pat Macaron", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });

        }

        private static void InitRaitir(List<MerchantDTO> merchants)
        {
            var raitir = new MerchantDTO() { Name = "Raitir", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            raitir.Locations = new List<string>() { "Yorn's Cradle", "Unfinished Garden", "Black Anvil Mine", "Iron Hammer Mine", "Hall of Promise" };
            raitir.Items.Add(new MerchantItem() { Itemname = "Piyer's Secret Textbook", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            raitir.Items.Add(new MerchantItem() { Itemname = "Fargar's Beer", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            raitir.Items.Add(new MerchantItem() { Itemname = "Great Castle Neria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            raitir.Items.Add(new MerchantItem() { Itemname = "Piyer", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            raitir.Items.Add(new MerchantItem() { Itemname = "Kaysarr", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            raitir.Items.Add(new MerchantItem() { Itemname = "Back Alley Rum", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });

        }

        private static void InitDorella(List<MerchantDTO> merchants)
        {
            var dorella = new MerchantDTO() { Name = "Dorella", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            dorella.Locations = new List<string>() { "Kallazar" };
            dorella.Items.Add(new MerchantItem() { Itemname = "Dessicated Wooden Statue", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Broken Dagger", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Book of Survival", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Red Moon's Tears", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Goulding Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            dorella.Items.Add(new MerchantItem() { Itemname = "Levi", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            dorella.Items.Add(new MerchantItem() { Itemname = "Kaldor", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            dorella.Items.Add(new MerchantItem() { Itemname = "Blood Pudding Chunk", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });

        }

        private static void InitRayni(List<MerchantDTO> merchants)
        {
            var rayni = new MerchantDTO() { Name = "Rayni", Items = new List<MerchantItem>(), Locations = new List<string>() };

            // Init Locations
            rayni.Locations = new List<string>() { "Tideshelf Path", "Starsand Beach", "Tikatika Colony", "Secret Forest" };
            rayni.Items.Add(new MerchantItem() { Itemname = "Piñata Crafting Set", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Hollowfruit", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Rainbow Tikatika Flower", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Oreha Viewing Stone", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Seto Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Stella", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Cicerra", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Albion", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Blood Pudding Chunk", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });

        }
    }
}
