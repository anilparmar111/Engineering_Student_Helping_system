using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class PostData
    {
        [Key]
        public int postid { get; set; }
        public string richtext_file_path { get; set; }
        public DateTime uploadtime { get; set; }
        public string title { get; set; }
        public string uid { get; set; }
    }
}
