using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
