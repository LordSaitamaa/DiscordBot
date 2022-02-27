using Discord;
using System.Collections.Generic;
using System.Linq;
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
            var ben = new MerchantDTO() { Name = "Ben", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>()};

            // init Spawntime
            ben.SpawnTimes = new List<string> { "12:30", "15:30", "16:30", "18:30", "19:30", "22:30", "0:30", "3:30", "4:30", "6:30", "7:30", "10:30" };

            // Init Locations and Items
            ben.Locations = new List<LocationDTO>() 
            {
                new LocationDTO() { Continent = "Yudia", Area = "Ankumo Mountain", Hyperlink = "https://papunika.com/map/?z=10220&l=us" },
                new LocationDTO() { Continent = "Yudia", Area = "Loghill", Hyperlink = "https://papunika.com/map/?z=10211&l=us"},
                new LocationDTO() { Continent = "Rethramis", Area = "Rethramis Border", Hyperlink = "https://papunika.com/map/?z=10222&l=us" },
            };

            ben.Items.Add(new MerchantItem() { Itemname = "Fancier Bouquet", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Prideholme Potato", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Rehtramis Holy Water", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Surprise Chest", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            ben.Items.Add(new MerchantItem() { Itemname = "Prideholme Neria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            ben.Items.Add(new MerchantItem() { Itemname = "Varut Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            ben.Items.Add(new MerchantItem() { Itemname = "Siera Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });

            merchants.Add(ben);
        }

        private static void InitLucas(List<MerchantDTO> merchants)
        {
            var lucas = new MerchantDTO() { Name = "Lucas", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            lucas.SpawnTimes = new List<string> { "1:30", "4:30", "5:30", "7:30", "8:30", "11:30", "13:30", "16:30", "17:30", "19:30", "20:30", "23:30" };

            // Init Locations
            lucas.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Yudia", Area = "Saland Hill", Hyperlink = "https://papunika.com/map/?z=10611&l=us"},
                new LocationDTO() { Continent = "Yudia", Area = "Ozhorn Hill", Hyperlink = "https://papunika.com/map/?z=10619&l=us" },
            };


            lucas.Items.Add(new MerchantItem() { Itemname = "Yudia Spellbook", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            lucas.Items.Add(new MerchantItem() { Itemname = "Yudia Natural Salt", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            lucas.Items.Add(new MerchantItem() { Itemname = "Sky Reflection Oil", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            lucas.Items.Add(new MerchantItem() { Itemname = "Giant Worm Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            lucas.Items.Add(new MerchantItem() { Itemname = "Morina Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            lucas.Items.Add(new MerchantItem() { Itemname = "Thunder Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            merchants.Add(lucas);

        }

        private static void InitMalone(List<MerchantDTO> merchants)
        {
            var malone = new MerchantDTO() { Name = "Malone", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            malone.SpawnTimes = new List<string> { "12:30", "14:30", "17:30", "18:30", "20:30", "21:30", "0:30", "2:30", "5:30", "6:30", "8:30", "9:30" };

            // Init Locations
            malone.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "West Luterra", Area = "Mount Zagoras", Hyperlink = "https://papunika.com/map/?z=10811&l=us" },
                new LocationDTO() { Continent = "West Luterra", Area = "Lakebar", Hyperlink = "https://papunika.com/map/?z=10812&l=us" },
                new LocationDTO() { Continent = "West Luterra", Area = "Medrick Monastery", Hyperlink = "https://papunika.com/map/?z=10813&l=us" },
                new LocationDTO() { Continent = "West Luterra", Area = "Bilbrin Forest", Hyperlink = "https://papunika.com/map/?z=10814&l=us" },

            };

            malone.Items.Add(new MerchantItem() { Itemname = "Black Rose", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Lakebar Tomato Juice", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Stalwart Cage", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Chain War Chronicles", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            malone.Items.Add(new MerchantItem() { Itemname = "Berhart Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            malone.Items.Add(new MerchantItem() { Itemname = "Cadogan Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            malone.Items.Add(new MerchantItem() { Itemname = "Cassleford Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            malone.Items.Add(new MerchantItem() { Itemname = "Hairplant", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(malone);

        }

        private static void InitMorris(List<MerchantDTO> merchants)
        {
            var morris = new MerchantDTO() { Name = "Morris", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            morris.SpawnTimes = new List<string> { "1:30", "4:30", "5:30", "7:30", "8:30", "11:30", "13:30", "16:30", "17:30", "19:30", "20:30", "23:30" };

            // Init Locations
            morris.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "East Luterra", Area = "Dyorika Plains", Hyperlink = "https://papunika.com/map/?z=10816&l=us" },
                new LocationDTO() { Continent = "East Luterra", Area = "Sunbright Hill", Hyperlink = "https://papunika.com/map/?z=10817&l=us" },
                new LocationDTO() { Continent = "East Luterra", Area = "Flowring Orchard", Hyperlink = "https://papunika.com/map/?z=10818&l=us" },

            };

            morris.Items.Add(new MerchantItem() { Itemname = "Azenaporium Brooch", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Dyroika Straw Hat", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Model of Luterra's Sword", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Chain War Chronicles", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            morris.Items.Add(new MerchantItem() { Itemname = "Brinewt Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Morpheo Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Meehan Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Thunder Wings Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            morris.Items.Add(new MerchantItem() { Itemname = "Dry-aged Meat", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(morris);

        }

        private static void InitBurt(List<MerchantDTO> merchants)
        {
            var burt = new MerchantDTO() { Name = "Burt", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            burt.SpawnTimes = new List<string> { "12:30", "14:30", "17:30", "18:30", "20:30", "21:30", "0:30", "2:30", "5:30", "6:30", "8:30", "9:30" };

            // Init Locations
            burt.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "East Luterra", Area = "Blackrose Chapel", Hyperlink = "https://papunika.com/map/?z=10819&l=us" },
                new LocationDTO() { Continent = "East Luterra", Area = "Leyar Terrace", Hyperlink = "https://papunika.com/map/?z=10820&l=us" },
                new LocationDTO() { Continent = "East Luterra", Area = "Borea's Domain", Hyperlink = "https://papunika.com/map/?z=10821&l=us" },
                new LocationDTO() { Continent = "East Luterra", Area = "Croconys Seashore", Hyperlink = "https://papunika.com/map/?z=10823&l=us" },
            };

            burt.Items.Add(new MerchantItem() { Itemname = "Azenaporium Brooch", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Dyroika Straw Hat", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Model of Luterra's Sword", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Chain War Chronicles", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            burt.Items.Add(new MerchantItem() { Itemname = "Seria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            burt.Items.Add(new MerchantItem() { Itemname = "Nox Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            burt.Items.Add(new MerchantItem() { Itemname = "Thunder Wings Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            burt.Items.Add(new MerchantItem() { Itemname = "Hot Chocolate Coffee", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(burt);

        }

        private static void InitOliver(List<MerchantDTO> merchants)
        {
            var oliver = new MerchantDTO() { Name = "Oliver", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            oliver.SpawnTimes = new List<string> { "12:30", "14:30", "17:30", "18:30", "20:30", "21:30", "0:30", "2:30", "5:30", "6:30", "8:30", "9:30" };

            // Init Locations
            oliver.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Tortoyk", Area = "Seaswept Woods", Hyperlink = "https://papunika.com/map/?z=11011&l=us" },
                new LocationDTO() { Continent = "Tortoyk", Area = "Sweetwater Forest", Hyperlink = "https://papunika.com/map/?z=11012&l=us" },
                new LocationDTO() { Continent = "Tortoyk", Area = "Skyreach Steppe", Hyperlink = "https://papunika.com/map/?z=11013&l=us" },
                new LocationDTO() { Continent = "Tortoyk", Area = "Forest of Giants", Hyperlink = "https://papunika.com/map/?z=11014&l=us" },
            };

            oliver.Items.Add(new MerchantItem() { Itemname = "Mokoko Carrot", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Oversize Ladybug Doll", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Round Glass Piece", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Shy Wind FLower Pollen", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            oliver.Items.Add(new MerchantItem() { Itemname = "Egg of Creation Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            oliver.Items.Add(new MerchantItem() { Itemname = "Eolh Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            oliver.Items.Add(new MerchantItem() { Itemname = "Mokamoka Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            merchants.Add(oliver);

        }

        private static void InitMac(List<MerchantDTO> merchants)
        {
            var mac = new MerchantDTO() { Name = "Mac", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            mac.SpawnTimes = new List<string> { "1:30", "4:30", "5:30", "7:30", "8:30", "11:30", "13:30", "16:30", "17:30", "19:30", "20:30", "23:30" };

            // Init Locations
            mac.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Anikka", Area = "Delphi Township", Hyperlink = "https://papunika.com/map/?z=10721&l=us" },
                new LocationDTO() { Continent = "Anikka", Area = "Rattan Hill", Hyperlink = "https://papunika.com/map/?z=10722&l=us" },
                new LocationDTO() { Continent = "Anikka", Area = "Melody Forest", Hyperlink = "https://papunika.com/map/?z=10723&l=us" },
                new LocationDTO() { Continent = "Anikka", Area = "Twilight Mists", Hyperlink = "https://papunika.com/map/?z=10725&l=us" },
            };

            mac.Items.Add(new MerchantItem() { Itemname = "Tournament Entrance Stamp", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            mac.Items.Add(new MerchantItem() { Itemname = "Angler's Fishing Pole", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            mac.Items.Add(new MerchantItem() { Itemname = "Sir Valleylead Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            mac.Items.Add(new MerchantItem() { Itemname = "Sir Druden Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            mac.Items.Add(new MerchantItem() { Itemname = "Madam Moonscent Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            mac.Items.Add(new MerchantItem() { Itemname = "Wei Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            merchants.Add(mac);

        }

        private static void InitNox(List<MerchantDTO> merchants)
        {
            var nox = new MerchantDTO() { Name = "Nox", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            nox.SpawnTimes = new List<string> { "12:30", "14:30", "17:30", "18:30", "20:30", "21:30", "0:30", "2:30", "5:30", "6:30", "8:30", "9:30" };

            // Init Locations
            nox.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Arthetine", Area = "Arid Path", Hyperlink = "https://papunika.com/map/?z=10421&l=us" },
                new LocationDTO() { Continent = "Arthetine", Area = "Scraplands", Hyperlink = "https://papunika.com/map/?z=10422&l=us" },
                new LocationDTO() { Continent = "Arthetine", Area = "Nebel Horn", Hyperlink = "https://papunika.com/map/?z=10423&l=us" },
                new LocationDTO() { Continent = "Arthetine", Area = "Windbringer Hill", Hyperlink = "https://papunika.com/map/?z=10424&l=us" },
                new LocationDTO() { Continent = "Arthetine", Area = "Totrich", Hyperlink = "https://papunika.com/map/?z=10425&l=us" },
                new LocationDTO() { Continent = "Arthetine", Area = "Riza Falls", Hyperlink = "https://papunika.com/map/?z=10426&l=us" },
            };

            nox.Items.Add(new MerchantItem() { Itemname = "Fine Gramophone", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            nox.Items.Add(new MerchantItem() { Itemname = "Energy X7 Capsule", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            nox.Items.Add(new MerchantItem() { Itemname = "Bergstrom Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            nox.Items.Add(new MerchantItem() { Itemname = "Stern Neria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            nox.Items.Add(new MerchantItem() { Itemname = "Krause Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            nox.Items.Add(new MerchantItem() { Itemname = "Adrenaline-boosting fluid", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(nox);

        }

        private static void InitPeter(List<MerchantDTO> merchants)
        {
            var peter = new MerchantDTO() { Name = "Peter", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            peter.SpawnTimes = new List<string> { "12:30", "15:30", "16:30", "18:30", "19:30", "22:30", "0:30", "3:30", "4:30", "6:30", "7:30", "10:30" };

            // Init Locations
            peter.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "North Vern", Area = "Port Krona", Hyperlink = "https://papunika.com/map/?z=11111&l=us" },
                new LocationDTO() { Continent = "North Vern", Area = "Parna Forest", Hyperlink = "https://papunika.com/map/?z=11112&l=us" },
                new LocationDTO() { Continent = "North Vern", Area = "Fesnar Highland", Hyperlink = "https://papunika.com/map/?z=11113&l=us" },
                new LocationDTO() { Continent = "North Vern", Area = "Vernese Forest", Hyperlink = "https://papunika.com/map/?z=11114&l=us" },
                new LocationDTO() { Continent = "North Vern", Area = "Balankar Mountain", Hyperlink = "https://papunika.com/map/?z=11115&l=us" },
            };

            peter.Items.Add(new MerchantItem() { Itemname = "Exquisite Music Box", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Goblin Yam", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Magick Cloth", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Magick Crystal", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Queen's Knights Application", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Vern's Founding Coin", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            peter.Items.Add(new MerchantItem() { Itemname = "Payla Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            peter.Items.Add(new MerchantItem() { Itemname = "Gideon Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            peter.Items.Add(new MerchantItem() { Itemname = "Thar Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            merchants.Add(peter);

        }

        private static void InitJeffrey(List<MerchantDTO> merchants)
        {
            var jeffrey = new MerchantDTO() { Name = "Jeffrey", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            jeffrey.SpawnTimes = new List<string> { "1:30", "4:30", "5:30", "7:30", "8:30", "11:30", "13:30", "16:30", "17:30", "19:30", "20:30", "23:30" };

            // Init Locations
            jeffrey.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Shushire", Area = "Frozen Sea", Hyperlink = "https://papunika.com/map/?z=10321&l=us" },
                new LocationDTO() { Continent = "Shushire", Area = "Bitterwind Hill", Hyperlink = "https://papunika.com/map/?z=10322&l=us" },
                new LocationDTO() { Continent = "Shushire", Area = "Iceblood Plateau", Hyperlink = "https://papunika.com/map/?z=10323&l=us" },
                new LocationDTO() { Continent = "Shushire", Area = "Lake Eternity", Hyperlink = "https://papunika.com/map/?z=10324&l=us" },
                new LocationDTO() { Continent = "Shushire", Area = "Icewing Heights", Hyperlink = "https://papunika.com/map/?z=10325&l=us" },
            };

            jeffrey.Items.Add(new MerchantItem() { Itemname = "Shimmering Essence", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Siriu's Holy Book", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Javern Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Sian Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Madnick Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            jeffrey.Items.Add(new MerchantItem() { Itemname = "Sapphire Sardine", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(jeffrey);

        }

        private static void InitAricer(List<MerchantDTO> merchants)
        {
            var aricer = new MerchantDTO() { Name = "Aricer", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            aricer.SpawnTimes = new List<string> { "12:30", "14:30", "17:30", "18:30", "20:30", "21:30", "0:30", "2:30", "5:30", "6:30", "8:30", "9:30" };

            // Init Locations
            aricer.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Rohendel", Area = "Soaring Harbor", Hyperlink = "https://papunika.com/map/?z=10121&l=us" },
                new LocationDTO() { Continent = "Rohendel", Area = "Glass Lotus Lake", Hyperlink = "https://papunika.com/map/?z=10122&l=us" },
                new LocationDTO() { Continent = "Rohendel", Area = "Breezesome Brae", Hyperlink = "https://papunika.com/map/?z=10123&l=us" },
                new LocationDTO() { Continent = "Rohendel", Area = "Xeneela Ruins", Hyperlink = "https://papunika.com/map/?z=10124&l=us" },
                new LocationDTO() { Continent = "Rohendel", Area = "Elzowin's Shade", Hyperlink = "https://papunika.com/map/?z=10125&l=us" },
            };

            aricer.Items.Add(new MerchantItem() { Itemname = "Danube's Earrings", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Elemental's Feather", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Soundstone of Dawn", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Sylvain Queens' Blessing", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            aricer.Items.Add(new MerchantItem() { Itemname = "Alifer Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            aricer.Items.Add(new MerchantItem() { Itemname = "Lenora Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            aricer.Items.Add(new MerchantItem() { Itemname = "Gnosis Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            aricer.Items.Add(new MerchantItem() { Itemname = "Pit-A-Pat Macaron", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(aricer);

        }

        private static void InitRaitir(List<MerchantDTO> merchants)
        {
            var raitir = new MerchantDTO() { Name = "Raitir", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            raitir.SpawnTimes = new List<string> { "12:30", "15:30", "16:30", "18:30", "19:30", "22:30", "0:30", "3:30", "4:30", "6:30", "7:30", "10:30" };

            // Init Locations
            raitir.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Yorn", Area = "Yorn's Cradle", Hyperlink = "https://papunika.com/map/?z=11311&l=us" },
                new LocationDTO() { Continent = "Yorn", Area = "Unfinished Garden", Hyperlink = "https://papunika.com/map/?z=11312&l=us" },
                new LocationDTO() { Continent = "Yorn", Area = "Black Anvil Mine", Hyperlink = "https://papunika.com/map/?z=11313&l=us" },
                new LocationDTO() { Continent = "Yorn", Area = "Iron Hammer Mine", Hyperlink = "https://papunika.com/map/?z=11314&l=us" },
                new LocationDTO() { Continent = "Yorn", Area = "Hall of Promise", Hyperlink = "https://papunika.com/map/?z=11315&l=us" },
            };

            raitir.Items.Add(new MerchantItem() { Itemname = "Piyer's Secret Textbook", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            raitir.Items.Add(new MerchantItem() { Itemname = "Fargar's Beer", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            raitir.Items.Add(new MerchantItem() { Itemname = "Great Castle Neria Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            raitir.Items.Add(new MerchantItem() { Itemname = "Piyer", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            raitir.Items.Add(new MerchantItem() { Itemname = "Kaysarr", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            raitir.Items.Add(new MerchantItem() { Itemname = "Back Alley Rum", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(raitir);

        }

        private static void InitDorella(List<MerchantDTO> merchants)
        {
            var dorella = new MerchantDTO() { Name = "Dorella", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            dorella.SpawnTimes = new List<string> { "1:30", "4:30", "5:30", "7:30", "8:30", "11:30", "13:30", "16:30", "17:30", "19:30", "20:30", "23:30" };

            // Init Locations
            dorella.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Feiton", Area = "Kallazar", Hyperlink = "https://papunika.com/map/?z=10901&l=us" },
            };

            dorella.Items.Add(new MerchantItem() { Itemname = "Dessicated Wooden Statue", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Broken Dagger", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Book of Survival", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Red Moon's Tears", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            dorella.Items.Add(new MerchantItem() { Itemname = "Goulding Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            dorella.Items.Add(new MerchantItem() { Itemname = "Levi", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            dorella.Items.Add(new MerchantItem() { Itemname = "Kaldor", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            dorella.Items.Add(new MerchantItem() { Itemname = "Blood Pudding Chunk", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(dorella);

        }

        private static void InitRayni(List<MerchantDTO> merchants)
        {
            var rayni = new MerchantDTO() { Name = "Rayni", Items = new List<MerchantItem>(), Locations = new List<LocationDTO>() };

            // init Spawntime
            rayni.SpawnTimes = new List<string> { "12:30", "14:30", "17:30", "18:30", "20:30", "21:30", "0:30", "2:30", "5:30", "6:30", "8:30", "9:30" };

            // Init Locations
            rayni.Locations = new List<LocationDTO>()
            {
                new LocationDTO() { Continent = "Punika", Area = "Tideshelf Path", Hyperlink = "https://papunika.com/map/?z=11411&l=us" },
                new LocationDTO() { Continent = "Punika", Area = "Starsand Beach", Hyperlink = "https://papunika.com/map/?z=11412&l=us" },
                new LocationDTO() { Continent = "Punika", Area = "Tikatika Colony", Hyperlink = "https://papunika.com/map/?z=11413&l=us" },
                new LocationDTO() { Continent = "Punika", Area = "Secret Forest", Hyperlink = "https://papunika.com/map/?z=11414&l=us" },
            };

            rayni.Items.Add(new MerchantItem() { Itemname = "Piñata Crafting Set", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Hollowfruit", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Rainbow Tikatika Flower", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Oreha Viewing Stone", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Rapport });
            rayni.Items.Add(new MerchantItem() { Itemname = "Seto Card", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Stella", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Cicerra", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Albion", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Card });
            rayni.Items.Add(new MerchantItem() { Itemname = "Blood Pudding Chunk", emote = _guildEmotes.FirstOrDefault(x => x.Name == "lostarkTest"), category = eItemCategory.Ingredient });
            merchants.Add(rayni);

        }
    }
}
