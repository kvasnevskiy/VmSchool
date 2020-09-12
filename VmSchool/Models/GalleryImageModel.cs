using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VmSchool.Models
{
    public class GalleryImageModel
    {
        public int Id { get; set; }
        public string ThumbnailPath { get; set; }
        public string ImagePath { get; set; }
        public GalleryModel Gallery { get; set; }
    }
}