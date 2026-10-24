using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    public class CompanyHome : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
