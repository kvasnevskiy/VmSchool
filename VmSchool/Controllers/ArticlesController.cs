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
            var res = mapper.Map<IEnumerable<ArticleModel>>(
                blManager.GetArticles((int) DefaultArticleCategory.NewsCategory));
            return View(new ArticlesViewModel
            {
                Articles = mapper.Map<IEnumerable<ArticleModel>>(blManager.GetArticles((int)DefaultArticleCategory.NewsCategory))
            });
        }

        [HttpGet]
        public IActionResult ShowArticle(int id)
        {
            using var blManager = new BusinessLogicManagerModel();
            return View("Article", mapper.Map<ArticleModel>(blManager.GetArticle(id)));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                using var blManager = new BusinessLogicManagerModel();

                //ArticleModel user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                //if (user != null)
                //    return View(user);
            }

            return NotFound();
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(User user)
        //{
        //    db.Users.Update(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
