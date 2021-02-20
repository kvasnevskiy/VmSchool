using System;
using System.Collections.Generic;
using System.Text;

namespace VmSchool.BL.Entities
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string ThumbnailPath { get; set; }
        public string ImagePath { get; set; }
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}
