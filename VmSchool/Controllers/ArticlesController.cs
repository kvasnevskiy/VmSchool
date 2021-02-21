using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VmSchool.BL;
using VmSchool.BL.Entities;
using VmSchool.Models;
using VmSchool.ViewModels;

namespace VmSchool.Controllers
{
    public class ArticlesController : BaseController
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
            return View("Article", mapper.Map<ArticleModel>(blManager.GetArticle(id)));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var t = mapper.Map<IEnumerable<ArticleCategoryModel>>(blManager.GetArticleCategories());
            ViewBag.ArticleCategories = new SelectList(mapper.Map<IEnumerable<ArticleCategoryModel>>(blManager.GetArticleCategories()), "Id", "Name");
            return View("NewArticle");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Article article)
        {
            if (article != null)
            {
                article.CreateDate = DateTime.Now;
                blManager.CreateArticle(article);
            }

            return Ok();
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id != null)
        //    {
        //        using var blManager = new BusinessLogicManagerModel();

        //        //ArticleModel user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
        //        //if (user != null)
        //        //    return View(user);
        //    }

        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(User user)
        //{
        //    db.Users.Update(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
