using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class MNetwork
    {
        
        public List<EshUser> friends { get; set; }
        public List<ReqUser> requsers { get; set; }
    }
}
