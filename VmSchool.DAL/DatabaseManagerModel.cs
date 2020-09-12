using VmSchool.DAL.EF;
using VmSchool.DAL.Entities;
using VmSchool.DAL.Interfaces;
using VmSchool.DAL.Repositories;

namespace VmSchool.DAL
{
    public class DatabaseManagerModel : IDatabaseManager
    {
        #region Database Context

        private readonly Context db;

        #endregion

        #region Repositories

        public IDatabaseRepository<Article> Articles { get; }
        public IDatabaseRepository<Gallery> Galleries { get; }
        public IDatabaseRepository<GalleryImage> GalleryImages { get; }

        #endregion

        #region Constructors

        public DatabaseManagerModel()
        {
            db = new Context();
            Articles = new ArticleRepository(db);
            Galleries = new GalleryRepository(db);
            GalleryImages = new GalleryImageRepository(db);
        }

        #endregion

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
