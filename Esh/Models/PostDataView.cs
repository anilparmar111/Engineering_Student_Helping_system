using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class PostDataView
    {
        public string title { get; set; }
        public string uid { get; set; }
        public DateTime uploadtime { get; set; }
        public string richtext { get; set; }
    }
}
