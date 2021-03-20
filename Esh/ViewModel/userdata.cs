using Esh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.ViewModel
{
    public class userdata
    {
        public EshUser EshUsers { get; set; }
        public List<PostDataView> pdvs { get; set; }
        //public List<PostData_W_Cmt> postData_W_Cmts { get; set; }
    }
}
