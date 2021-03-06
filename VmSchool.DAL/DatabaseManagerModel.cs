﻿using VmSchool.DAL.EF;
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

        public IDatabaseRepository<User> Users { get; }
        public IDatabaseRepository<Article> Articles { get; }
        public IDatabaseRepository<ArticleCategory> ArticleCategories { get; }
        public IDatabaseRepository<Gallery> Galleries { get; }
        public IDatabaseRepository<GalleryImage> GalleryImages { get; }
        public IDatabaseRepository<Setting> Settings { get; }

        #endregion

        #region Constructors

        public DatabaseManagerModel()
        {
            db = new Context();
            Users = new UserRepository(db);
            Articles = new ArticleRepository(db);
            ArticleCategories = new ArticleCategoriesRepository(db);
            Galleries = new GalleryRepository(db);
            GalleryImages = new GalleryImageRepository(db);
            Settings = new SettingsRepository(db);
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
