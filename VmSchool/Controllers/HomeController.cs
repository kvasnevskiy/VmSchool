using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VmSchool.Models;
using VmSchool.ViewModels;
using  VmSchool.BL;

namespace VmSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly Mapper mapper;

        public HomeController()
        {
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<BL.Entities.Article, ArticleModel>()));
        }

        [HttpGet]
        public IActionResult Index()
        {
            using var blManager = new BusinessLogicManagerModel();

            return View(new HomeViewModel
            {
                Articles = mapper.Map<IEnumerable<ArticleModel>>(blManager.GetArticles((int)DefaultArticleCategory.NewsCategory))
            });
        }
    }
}