using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VmSchool.Models
{
    public class GalleryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string ThumbnailPath => Images.FirstOrDefault()?.ThumbnailPath;
        public List<GalleryImageModel> Images { get; set; }
    }
}
