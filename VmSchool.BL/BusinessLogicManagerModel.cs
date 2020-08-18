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

        public void Dispose()
        {
            databaseManager.Dispose();
        }
    }
}
