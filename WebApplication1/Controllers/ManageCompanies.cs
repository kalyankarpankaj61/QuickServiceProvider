using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ManageCompanies : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
