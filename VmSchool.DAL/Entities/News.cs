﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VmSchool.DAL.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string ThumbnailPath { get; set; }
    }
}
