using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VmSchool.Models;

namespace VmSchool.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
