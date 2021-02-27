using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Post_New
    {
        [Key]
        public int postid { get; set; }
        public string uid;
        public DateTime uploadtime;
        public string richtext_file_path;
        public string title { get; set; }
    }
}
