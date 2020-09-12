using System.Collections.Generic;

namespace VmSchool.BL.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public ICollection<GalleryImage> Images { get; set; }
    }
}
