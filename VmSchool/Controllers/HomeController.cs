using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VmSchool.Models;
using VmSchool.ViewModels;
using VmSchool.BL;

namespace VmSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly Mapper mapper;
        private readonly BusinessLogicManagerModel blManager;

        public HomeController()
        {
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<BL.Entities.Article, ArticleModel>()));
            blManager = new BusinessLogicManagerModel();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new HomeViewModel
            {
                Articles = mapper.Map<IEnumerable<ArticleModel>>(blManager.GetArticles((int)DefaultArticleCategory.NewsCategory))
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            blManager.Dispose();
        }
    }
}