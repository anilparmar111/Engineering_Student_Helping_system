using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class EshUser
    {
        [Key]
        public int EshUserUserId { get; set; }
        public string emailid { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string name { get; set; }
        public string Persnal_Site_URL { get; set; }
        [Required(ErrorMessage = "designation is Required")]
        public string designation { get; set; }
        //public string photopath;
        public string about { get; set; }
        
        public bool gender { get; set; }

        public string Schoolname { get; set; }
        /*public string Start_Time;
        public bool Currently_Pursuing;
        public string End_Time;
        public string cgpa;
        public string About;


        public string Organizationname;
        public string Website_URL;
        //public string photopath;
        public string about_Organization;
        public string location;*/
        //public IList<EshUserEducation> EshUserEducation { get; set; }

        //public IEnumerable<Education> Education { get; set; }

        //public string EducationId;
        //public int EducationId { get; set; }
        //public IList<Education> Education { get; set; }
        //public ICollection<Organization> Organization { get; set; }
        //public ICollection<Skill> Skill { get; set; }

        //("User")]
        //public string EducationId { get; set; }
        //public Education Education { get; set; }


        //public List<Organization> Organizations { get; set; }
        //public List<Skill> Skills { get; set; }

        //public string OrganizationId;
        //public Organization Organization { get; set; }

        //public string SkillId;
        //public Organization Skill { get; set; }


    }
}
