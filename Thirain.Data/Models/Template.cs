using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirain.Data.Models
{
    public class Template : Entity
    {
        public int TemplateType { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
    }
}
