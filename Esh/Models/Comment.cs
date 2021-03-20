using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Comment
    {
        public string postid;
        public string uid { get; set; }
        public DateTime Cooment_time;
        public string coomenttext;
    }
}