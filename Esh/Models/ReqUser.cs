using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class ReqUser
    {
        public string uid { get; set; }
        public string  name { get; set; }
        public string school { get; set; }
        public string designation { get; set; }
        public DateTime reqtime { get; set; }
    }
}
