using Core;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    public class MainCategoriesHomeController : Controller
    {
        IMainCategoryrepo mainCategoryrepo;
        public MainCategoriesHomeController(IMainCategoryrepo mainCategoryrepo)
        {
            this.mainCategoryrepo = mainCategoryrepo;
        }

        public async Task< IActionResult> Index()
        {
            var res= await this.mainCategoryrepo.GetAll();
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(MainCategory rec)
        {
            if(ModelState.IsValid)
            {
                var res= await this.mainCategoryrepo.Insert(rec);
                if(res.IsSuccess)
                {
                    TempData["Message"] = res.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"]=res.Message;
                    return View(res);
                }
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Int64 id)
        {
            var res= await this.mainCategoryrepo.GetById(id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MainCategory rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this.mainCategoryrepo.Update(rec);
                if (res.IsSuccess)
                {
                    TempData["Message"] = res.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = res.Message;
                    return View(res);
                }
            }
            return View(rec);
        }
        public async Task<IActionResult> Delete(Int64 id)
        {
            var res =await this.mainCategoryrepo.Delete(id);
            TempData["Message"] = res.Message;
            return RedirectToAction("Index");
        }
    }
}
