using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                cfg.CreateMap<ArticleModel, BL.Entities.Article>();
            }));
        }

        [HttpGet]
        public IActionResult News()
        {
            return View("News",
                new ArticlesViewModel
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
            ViewBag.ArticleCategories = new SelectList(mapper.Map<IEnumerable<ArticleCategoryModel>>(blManager.GetArticleCategories()), "Id", "Name");
            return View("ArticleEdit");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(ArticleModel article)
        {
            if (article != null)
            {
                if (article.Id > 0)
                {
                    blManager.UpdateArticle(mapper.Map<BL.Entities.Article>(article));
                }
                else
                {
                    article.CreateDate = DateTime.Now;
                    blManager.CreateArticle(mapper.Map<BL.Entities.Article>(article));
                }
            }

            return RedirectToAction("Management");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Cancel()
        {
            return RedirectToAction("Management");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Management()
        {
            return View("Management", new ArticlesViewModel
            {
                Articles = mapper.Map<IEnumerable<ArticleModel>>(blManager.GetArticles())
            });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.ArticleCategories = new SelectList(mapper.Map<IEnumerable<ArticleCategoryModel>>(blManager.GetArticleCategories()), "Id", "Name");
            
            return View("ArticleEdit", mapper.Map<ArticleModel>(blManager.GetArticle(id)));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            blManager.DeleteArticle(id);

            return RedirectToAction("Management");
        }
    }
}
