using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Friend
    {
        //[Key]
        //[Column(Order = 1)]
        public string uid { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public string fid { get; set; }
    }
}
