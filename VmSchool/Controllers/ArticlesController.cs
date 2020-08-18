using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VmSchool.BL;
using VmSchool.Models;
using VmSchool.ViewModels;

namespace VmSchool.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly Mapper mapper;

        public ArticlesController()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BL.Entities.ArticleCategory, ArticleCategoryModel>();
                cfg.CreateMap<BL.Entities.Article, ArticleModel>();
            }));
        }

        [HttpGet]
        public IActionResult Index()
        {
            using var blManager = new BusinessLogicManagerModel();
            return View(new ArticlesViewModel
            {
                Articles = mapper.Map<IEnumerable<ArticleModel>>(blManager.GetArticles((int)DefaultArticleCategory.NewsCategory))
            });
        }

        [HttpGet]
        public IActionResult ShowArticle(int id)
        {
            using var blManager = new BusinessLogicManagerModel();
            return View(mapper.Map<ArticleModel>(blManager.GetArticle(id)));
        }
    }
}
