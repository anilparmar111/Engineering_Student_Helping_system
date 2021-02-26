using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Skill
    {
        [Key]
        public int Id;
        public string skillname;
        public string Experinse;
        public int UserId;
        //[System.ComponentModel.DataAnnotations.ForeignKey("UserId")]
        public EshUser User { get; set; }
    }
}
