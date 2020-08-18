using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VmSchool.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string ThumbnailPath { get; set; }
    }
}
