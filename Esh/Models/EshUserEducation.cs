using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class EshUserEducation
    {
        public int EshUserId { get; set; }
        public EshUser EshUser { get; set; }

        public int EducationId { get; set; }
        public Education Education { get; set; }
    }
}
