﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VmSchool.DAL.EF;
using VmSchool.DAL.Entities;
using VmSchool.DAL.Interfaces;

namespace VmSchool.DAL.Repositories
{
    public class ArticleRepository : IDatabaseRepository<Article>
    {
        private readonly Context db;

        public ArticleRepository(Context db)
        {
            this.db = db;
        }

        public IEnumerable<Article> ReadAll()
        {
            return db.Articles.Include(i => i.Category);
        }

        public Article Read(int id)
        {
            return db.Articles.Include(i => i.Category).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Article> ReadByExpression(Expression<Func<Article, bool>> predicate)
        {
            return db.Articles.Where(predicate).Include(i => i.Category);
        }

        public void Create(Article item)
        {
            db.Articles.Add(item);
        }

        public void Update(Article item)
        {
            db.Articles.Update(item);
        }

        public void Delete(int id)
        {
            var item = db.Articles.Find(id);
            
            if (item != null)
            {
                db.Articles.Remove(item);
            }
        }
    }
}
