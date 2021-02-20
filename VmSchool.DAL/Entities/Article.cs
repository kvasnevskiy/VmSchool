using System;

namespace VmSchool.DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string ThumbnailPath { get; set; }
        public int CategoryId { get; set; }
        public ArticleCategory Category { get; set; }
    }
}
