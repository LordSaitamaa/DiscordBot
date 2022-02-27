using System.Collections.Generic;

namespace Thirain.Model
{
    public class MerchantDTO
    {
        public string Name { get; set; }
        public List<MerchantItem> Items { get; set;}
        public List<LocationDTO> Locations { get; set; }
        public List<string> SpawnTimes { get; set; }
    }
}
