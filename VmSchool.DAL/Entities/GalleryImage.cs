using System;
using System.Collections.Generic;
using System.Text;

namespace VmSchool.DAL.Entities
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string ThumbnailPath { get; set; }
        public string ImagePath { get; set; }
    }
}
