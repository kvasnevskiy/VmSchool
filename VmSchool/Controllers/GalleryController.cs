using System.Collections.Generic;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VmSchool.BL;
using VmSchool.Models;
using VmSchool.ViewModels;

namespace VmSchool.Controllers
{
    public class GalleryController : Controller
    {
        private readonly Mapper mapper;

        public GalleryController()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BL.Entities.Gallery, GalleryModel>();
                cfg.CreateMap<BL.Entities.GalleryImage, GalleryImageModel>()
                    .AfterMap((src, dest) =>
                    {
                        dest.ThumbnailPath = Path.Combine(src.Gallery.Path, src.ThumbnailPath);
                        dest.ImagePath = Path.Combine(src.Gallery.Path, src.ImagePath);
                    });
            }));
        }

        [HttpGet]
        public IActionResult Index()
        {
            using var blManager = new BusinessLogicManagerModel();

            var res = mapper.Map<IEnumerable<GalleryModel>>(blManager.GetGalleries());

            return View(new GalleryViewModel()
            {
                Galleries = mapper.Map<IEnumerable<GalleryModel>>(blManager.GetGalleries())
            });
        }

        [HttpGet]
        public IActionResult ShowGallery(int id)
        {
            using var blManager = new BusinessLogicManagerModel();
            return View("Gallery", mapper.Map<GalleryModel>(blManager.GetGallery(id)));
        }
    }
}
