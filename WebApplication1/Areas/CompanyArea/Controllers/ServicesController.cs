using Core;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    public class ServicesController : Controller
    {
        
        IServiceRepo servicesRepo;
        ISubCategoryRepo SubCategoryRepo;
        IMainCategoryrepo mainCategoryrepo;
        public ServicesController(IServiceRepo servicesRepo, ISubCategoryRepo subCategoryRepo, IMainCategoryrepo mainCategoryrepo)
        {
            this.servicesRepo = servicesRepo;
            this.SubCategoryRepo = subCategoryRepo;
            this.mainCategoryrepo = mainCategoryrepo;
        }

        public async Task<IActionResult> Index()
        {
            var res = await this.servicesRepo.GetAll();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategories = new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName"); 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Service rec)
        {
            
            ViewBag.MainCategories = new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName");
            if (ModelState.IsValid)
            {
                var res = await this.servicesRepo.Insert(rec);
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
            var res = await this.servicesRepo.GetById(id);
            ViewBag.MainCategories = new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName");
            ViewBag.SubCategories = new SelectList(await this.SubCategoryRepo.GetAll(), "SubCategoryID", "SubCategoryName",res.SubCategoryID);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Service rec)
        {
            ViewBag.MainCategories = new SelectList(await this.mainCategoryrepo.GetAll(), "MainCategoryID", "MainCategoryName");
            ViewBag.SubCategories = new SelectList(await this.SubCategoryRepo.GetAll(), "SubCategoryID", "SubCategoryName",rec.SubCategoryID);
            if (ModelState.IsValid)
            {
                var res = await this.servicesRepo.Update(rec);
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
            var res = await this.servicesRepo.Delete(id);
            TempData["Message"] = res.Message;
            return RedirectToAction("Index");
        }
    }
}
