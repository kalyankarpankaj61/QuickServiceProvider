using Core;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    public class SubCategoriesHomeController : Controller
    {
        IMainCategoryrepo mainCategoryrepo;
        ISubCategoryRepo SubCategoryRepo;
        public SubCategoriesHomeController(IMainCategoryrepo mainCategoryrepo, ISubCategoryRepo subCategoryRepo)
        {
            this.mainCategoryrepo = mainCategoryrepo;
            this.SubCategoryRepo = subCategoryRepo;
        }

        public async Task<IActionResult> Index()
        {
            var res = await this.SubCategoryRepo.GetAll();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategories=new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubCategory rec)
        {
            ViewBag.MainCategories = new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName");
            if (ModelState.IsValid)
            {
                var res = await this.SubCategoryRepo.Insert(rec);
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
        [HttpGet]
        // edit get method 
        public async Task<IActionResult> Edit(Int64 id)
        {
            var res = await this.SubCategoryRepo.GetById(id);
            ViewBag.MainCategories = new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName");
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SubCategory rec)
        {
            ViewBag.MainCategories = new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName");
            if (ModelState.IsValid)
            {
                var res = await this.SubCategoryRepo.Update(rec);
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
            var res = await this.SubCategoryRepo.Delete(id);
            TempData["Message"] = res.Message;
            return RedirectToAction("Index");
        }
    }
}
