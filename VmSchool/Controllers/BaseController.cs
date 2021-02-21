using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VmSchool.BL;

namespace VmSchool.Controllers
{
    public class BaseController : Controller
    {
        protected readonly BusinessLogicManagerModel blManager;

        public BaseController()
        {
            blManager = new BusinessLogicManagerModel();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewData["SiteName"] = blManager.SettingsManager.GetValue<string>("siteName");
            ViewData["Copyright"] = blManager.SettingsManager.GetValue<string>("copyright");

            base.OnActionExecuted(context);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            blManager.Dispose();
        }
    }
}