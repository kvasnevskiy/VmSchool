using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VmSchool.Models;

namespace VmSchool.ViewModels
{
    public class GalleryViewModel
    {
        public IEnumerable<GalleryModel> Galleries { get; set; }
    }
}
