using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VmSchool.DAL.Entities;

namespace VmSchool.DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=VmSchoolDB;Trusted_Connection=True;");
        }
    }
}
