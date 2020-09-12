using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VmSchool.DAL.EF;
using VmSchool.DAL.Entities;
using VmSchool.DAL.Interfaces;

namespace VmSchool.DAL.Repositories
{
    public class GalleryRepository : IDatabaseRepository<Gallery>
    {
        private readonly Context db;

        public GalleryRepository(Context db)
        {
            this.db = db;
        }

        public IEnumerable<Gallery> ReadAll()
        {
            return db.Galleries.Include(g => g.Images);
        }

        public Gallery Read(int id)
        {
            return db.Galleries.Include(g => g.Images).FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gallery> ReadByExpression(Expression<Func<Gallery, bool>> predicate)
        {
            return db.Galleries.Where(predicate);
        }

        public void Create(Gallery item)
        {
            db.Galleries.Add(item);
        }

        public void Update(Gallery item)
        {
            db.Galleries.Update(item);
        }

        public void Delete(int id)
        {
            var item = db.Galleries.Find(id);

            if (item != null)
            {
                db.Galleries.Remove(item);
            }
        }
    }
}
