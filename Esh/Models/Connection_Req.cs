﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Connection_Req
    {
        //[Key]
        //[Column(Order = 1)]
        public string requestuser { get; set; }

        //[Key]
        //[Column(Order = 2)]
        public string Recivername { get; set; }

        public DateTime time { get; set; }
    }
}
