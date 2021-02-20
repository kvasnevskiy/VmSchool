﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using VmSchool.BL.Entities;
using VmSchool.DAL;
using VmSchool.DAL.Interfaces;

namespace VmSchool.BL
{
    public class BusinessLogicManagerModel : IDisposable
    {
        private readonly IDatabaseManager databaseManager;
        private readonly Mapper mapper;

        public BusinessLogicManagerModel()
        {
            databaseManager = new DatabaseManagerModel();

            mapper = new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Entities.ArticleCategory, VmSchool.BL.Entities.ArticleCategory>();
                    cfg.CreateMap<DAL.Entities.Article, VmSchool.BL.Entities.Article>();
                    cfg.CreateMap<DAL.Entities.Gallery, VmSchool.BL.Entities.Gallery>();
                    cfg.CreateMap<DAL.Entities.GalleryImage, VmSchool.BL.Entities.GalleryImage>();
                    cfg.CreateMap<DAL.Entities.User, VmSchool.BL.Entities.User>();
                }));
        }

        public IEnumerable<VmSchool.BL.Entities.Article> GetArticles(int categoryId)
        {
            return mapper.Map<IEnumerable<Article>>(databaseManager.Articles.ReadByExpression(a => a.Category.Id == categoryId));
        }

        public VmSchool.BL.Entities.Article GetArticle(int id)
        {
            return mapper.Map<Article>(databaseManager.Articles.Read(id));
        }

        public void CreateArticle(VmSchool.BL.Entities.Article article)
        {
            //var newArticle = new DAL.Entities.Article
            //{
            //    Title = article.Title,
            //    Category = article.Category.,
            //    CreateDate = DateTime.Now,
            //    Description = article.Description
            //};
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
