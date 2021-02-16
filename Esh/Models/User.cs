using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class User
    {
        [Key]
        public string email;
        public string name;
        public string Persnal_Site_URL;
        public string designation;
        public string photopath;
        public string about;
        public string location;
        
    }
}
