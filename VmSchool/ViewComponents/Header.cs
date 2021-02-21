using System;
using Microsoft.AspNetCore.Mvc;
using VmSchool.BL;

namespace VmSchool.ViewComponents
{
    public class Header : ViewComponent, IDisposable
    {
        private readonly BusinessLogicManagerModel blManager;

        public Header()
        {
            blManager = new BusinessLogicManagerModel();
        }

        public IViewComponentResult Invoke()
        {
            return View("Default", blManager.SettingsManager.GetValue<string>("siteName"));
        }

        public void Dispose()
        {
            blManager?.Dispose();
        }
    }
}