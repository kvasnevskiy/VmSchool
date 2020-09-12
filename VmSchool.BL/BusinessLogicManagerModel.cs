using System;
using System.Collections.Generic;
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

        public void Dispose()
        {
            databaseManager.Dispose();
        }
    }
}
