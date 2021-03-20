using Esh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.ViewModel
{
    public class PostData_W_Cmt
    {
        public PostDataView PostDataViews { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
