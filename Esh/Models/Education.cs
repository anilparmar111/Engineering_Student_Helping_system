using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esh.Models
{
    public class Education
    {
        [Key]
        public int EducationId;
        public string Schoolname { get; set; }
        public DateTime Start_Time;
        public bool Currently_Pursuing;
        public DateTime End_Time;
        public string cgpa;
        public string About;
        public IList<EshUserEducation> EshUserEducation { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
        //public int UserId;
        //[System.ComponentModel.DataAnnotations.ForeignKey("UserId")]
        //public User User { get; set; }

        //public ICollection<User> User { get; set; }

        //[ForeignKey("User")]
        //public string email { get; set; }
        //public User User { get; set; }
    }
}
