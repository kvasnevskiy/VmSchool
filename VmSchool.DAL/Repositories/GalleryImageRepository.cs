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
    public class GalleryImageRepository : IDatabaseRepository<GalleryImage>
    {
        private readonly Context db;

        public GalleryImageRepository(Context db)
        {
            this.db = db;
        }

        public IEnumerable<GalleryImage> ReadAll()
        {
            return db.GalleryImages;
        }

        public GalleryImage Read(int id)
        {
            return db.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> ReadByExpression(Expression<Func<GalleryImage, bool>> predicate)
        {
            return db.GalleryImages.Where(predicate);
        }

        public void Create(GalleryImage item)
        {
            db.GalleryImages.Add(item);
        }

        public void Update(GalleryImage item)
        {
            db.GalleryImages.Update(item);
        }

        public void Delete(int id)
        {
            var item = db.GalleryImages.Find(id);

            if (item != null)
            {
                db.GalleryImages.Remove(item);
            }
        }
    }
}
