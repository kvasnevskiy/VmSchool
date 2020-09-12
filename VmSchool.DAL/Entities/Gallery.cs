using System;
using System.Collections.Generic;
using System.Text;

namespace VmSchool.DAL.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public ICollection<GalleryImage> Images { get; set; }
    }
}
