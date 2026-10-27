using Core;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CompanyArea.Controllers
{
     [Area("CompanyArea")]
    public class DispatchAgenciesController : Controller
    {
        IDispatchAgencyRepo dispatchAgencyRepo;
        public DispatchAgenciesController(IDispatchAgencyRepo dispatchAgencyRepo)
        {
            this.dispatchAgencyRepo = dispatchAgencyRepo;
        }

        public async Task<IActionResult> Index()
        {
            var res = await this.dispatchAgencyRepo.GetAll();
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DispatchAgency rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this.dispatchAgencyRepo.Insert(rec);
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
        public async Task<IActionResult> Edit(Int64 id)
        {
            var res = await this.dispatchAgencyRepo.GetById(id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DispatchAgency rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this.dispatchAgencyRepo.Update(rec);
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
            var res = await this.dispatchAgencyRepo.Delete(id);
            TempData["Message"] = res.Message;
            return RedirectToAction("Index");
        }
    }
}
