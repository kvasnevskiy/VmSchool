using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VmSchool.DAL.EF;
using VmSchool.DAL.Entities;
using VmSchool.DAL.Interfaces;

namespace VmSchool.DAL.Repositories
{
    public class ArticleCategoriesRepository : IDatabaseRepository<ArticleCategory>
    {
        private readonly Context db;

        public ArticleCategoriesRepository(Context db)
        {
            this.db = db;
        }

        public IEnumerable<ArticleCategory> ReadAll()
        {
            return db.ArticleCategories;
        }

        public ArticleCategory Read(int id)
        {
            return db.ArticleCategories.Find(id);
        }

        public IEnumerable<ArticleCategory> ReadByExpression(Expression<Func<ArticleCategory, bool>> predicate)
        {
            return db.ArticleCategories.Where(predicate);
        }

        public void Create(ArticleCategory item)
        {
            db.ArticleCategories.Add(item);
        }

        public void Update(ArticleCategory item)
        {
            db.ArticleCategories.Update(item);
        }

        public void Delete(int id)
        {
            var item = db.ArticleCategories.Find(id);

            if (item != null)
            {
                db.ArticleCategories.Remove(item);
            }
        }
    }
}
