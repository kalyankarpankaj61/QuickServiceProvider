using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    public class CompanyHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
