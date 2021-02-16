using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Organization
    {
        [Key]
        public string email;
        public string name;
        public string Website_URL;
        public string photopath;
        public string about;
        public string location;
    }
}
