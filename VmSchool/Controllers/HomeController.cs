﻿using Microsoft.AspNetCore.Mvc;

namespace VmSchool.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}