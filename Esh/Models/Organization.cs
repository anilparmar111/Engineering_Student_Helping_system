using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Organizationname;
        public string Website_URL;
        //public string photopath;
        public string about;
        public string location;

        public int UserId;
        //[System.ComponentModel.DataAnnotations.ForeignKey("UserId")]
        public EshUser User { get; set; }
    }
}
