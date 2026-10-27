using Infra.Dtos;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ManageCompanies : Controller
    {
        ICompanyRepo _companyrepo;
        public ManageCompanies(ICompanyRepo companyrepo)
        {
            this._companyrepo = companyrepo;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto rec)
        {
            if(ModelState.IsValid)
            {
                var res = await this._companyrepo.Login(rec);
                if (res.IsLoggedIn)
                {
                    return RedirectToAction("Index", "CompanyHome", new {area= "CompanyArea"});
                }
                ModelState.AddModelError("", res.Message);
                return View(rec);
            }
            return View(rec);
        }
    }
}
