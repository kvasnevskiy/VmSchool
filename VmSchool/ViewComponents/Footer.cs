using System;
using Microsoft.AspNetCore.Mvc;
using VmSchool.BL;

namespace VmSchool.ViewComponents
{
    public class Footer : ViewComponent, IDisposable
    {
        private readonly BusinessLogicManagerModel blManager;

        public Footer()
        {
            blManager = new BusinessLogicManagerModel();
        }

        public IViewComponentResult Invoke()
        {
            return View("Default",(blManager.SettingsManager.GetValue<string>("copyright"), DateTime.Now.ToString("yyyy")));
        }

        public void Dispose()
        {
            blManager?.Dispose();
        }
    }
}