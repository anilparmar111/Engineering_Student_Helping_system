using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Create_Post
    {
        [Required(ErrorMessage = "*please provide Title")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description Is Required")]
        public string textfile { get; set; }

       
    }
}