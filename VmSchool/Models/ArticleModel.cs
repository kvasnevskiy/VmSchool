﻿using System;

namespace VmSchool.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string ThumbnailPath { get; set; }
        public int CategoryId { get; set; }
        public ArticleCategoryModel Category { get; set; }
    }
}