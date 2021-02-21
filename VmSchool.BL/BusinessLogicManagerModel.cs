using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VmSchool.BL.Entities;
using VmSchool.BL.Managers.Settings;
using VmSchool.DAL;
using VmSchool.DAL.Interfaces;

namespace VmSchool.BL
{
    public class BusinessLogicManagerModel : IDisposable
    {
        private readonly IDatabaseManager databaseManager;
        private readonly Mapper mapper;

        public ISettingsManager SettingsManager { get; }

        public BusinessLogicManagerModel()
        {
            databaseManager = new DatabaseManagerModel();

            mapper = new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Entities.ArticleCategory, VmSchool.BL.Entities.ArticleCategory>();
                    cfg.CreateMap<DAL.Entities.Article, VmSchool.BL.Entities.Article>();
                    cfg.CreateMap<BL.Entities.Article, DAL.Entities.Article>();
                    cfg.CreateMap<DAL.Entities.Gallery, VmSchool.BL.Entities.Gallery>();
                    cfg.CreateMap<DAL.Entities.GalleryImage, VmSchool.BL.Entities.GalleryImage>();
                    cfg.CreateMap<DAL.Entities.User, VmSchool.BL.Entities.User>();
                    cfg.CreateMap<DAL.Entities.Setting, VmSchool.BL.Entities.Setting>();
                }));

            SettingsManager = new SettingsManagerModel(databaseManager);
        }

        public IEnumerable<VmSchool.BL.Entities.Article> GetArticles(int categoryId)
        {
            return mapper.Map<IEnumerable<Article>>(databaseManager.Articles.ReadByExpression(a => a.Category.Id == categoryId));
        }

        public VmSchool.BL.Entities.Article GetArticle(int id)
        {
            return mapper.Map<Article>(databaseManager.Articles.Read(id));
        }

        public BL.Entities.Article CreateArticle(BL.Entities.Article article)
        {
            var newArticle = mapper.Map<VmSchool.DAL.Entities.Article>(article);
            databaseManager.Articles.Create(newArticle);
            databaseManager.Save();

            return mapper.Map<BL.Entities.Article>(newArticle);
        }

        public IEnumerable<VmSchool.BL.Entities.ArticleCategory> GetArticleCategories()
        {
            return mapper.Map<IEnumerable<ArticleCategory>>(databaseManager.ArticleCategories.ReadAll());
        }

        public IEnumerable<VmSchool.BL.Entities.Gallery> GetGalleries()
        {
            return mapper.Map<IEnumerable<Gallery>>(databaseManager.Galleries.ReadAll());
        }

        public VmSchool.BL.Entities.Gallery GetGallery(int id)
        {
            return mapper.Map<Gallery>(databaseManager.Galleries.Read(id));
        }

        public IEnumerable<VmSchool.BL.Entities.GalleryImage> GetImages(int galleryId)
        {
            return mapper.Map<IEnumerable<GalleryImage>>(databaseManager.GalleryImages.ReadByExpression(g => g.Gallery.Id == galleryId));
        }

        public VmSchool.BL.Entities.User CreateUser(User user)
        {
            var newUser = new DAL.Entities.User
            {
                Email = user.Email,
                Password = user.Password
            };

            databaseManager.Users.Create(newUser);
            databaseManager.Save();

            return mapper.Map<User>(newUser);
        }

        public VmSchool.BL.Entities.User GetUser(string email, string password)
        {
            return mapper.Map<User>(databaseManager.Users.ReadByExpression(user => user.Email == email && user.Password == password).FirstOrDefault());
        }

        public void Dispose()
        {
            databaseManager.Dispose();
        }
    }
}
