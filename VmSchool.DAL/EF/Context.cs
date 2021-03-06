﻿using Microsoft.EntityFrameworkCore;
using VmSchool.DAL.Entities;

namespace VmSchool.DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=VmSchoolDB;Trusted_Connection=True;");
        }
    }
}
