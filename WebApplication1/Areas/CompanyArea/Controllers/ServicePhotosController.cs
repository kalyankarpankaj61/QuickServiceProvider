using Core;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    public class ServicePhotosController : Controller
    {
        IServicePhotosRepo ServicePhotosRepo;
        IServiceRepo serviceRepo;
        IWebHostEnvironment env;
        public ServicePhotosController(IServicePhotosRepo servicesPhotosRepo, IServiceRepo serviceRepo,IWebHostEnvironment env)
        {
            this.ServicePhotosRepo = servicesPhotosRepo;
            this.serviceRepo = serviceRepo;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            var res = await this.ServicePhotosRepo.GetAll();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Services = new SelectList(await this.serviceRepo.GetAll(), "ServiceID", "Title");
            ServicePhotos rec=new ServicePhotos();
            rec.UploadedDate= DateTime.Now;
            return View(rec);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServicePhotos rec)
        {
            ViewBag.SubCategories = new SelectList(await this.serviceRepo.GetAll(), "ServiceID", "Title");

            if (ModelState.IsValid)
            {
                if(rec.Photo==null || rec.Photo.Length==0)
                {
                    ModelState.AddModelError("Photo", "Please Select The Photo To Upload");
                    return View(rec);
                }
                else
                {
                    string folderpath =Path.Combine( this.env.WebRootPath,"servicephotos");
                    string filepath = Path.Combine(folderpath, rec.Photo.FileName);
                    FileStream fs = new FileStream(filepath,FileMode.Create);
                    rec.Photo.CopyTo(fs);
                    fs.Close();
                    rec.PhotoPath = "/servicephotos/" + rec.Photo.FileName;
                }
                var res = await this.ServicePhotosRepo.Insert(rec);
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

            var res = await this.ServicePhotosRepo.GetById(id);
            ViewBag.Services = new SelectList(await this.serviceRepo.GetAll(), "ServiceID", "Title");
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ServicePhotos rec)
        {
            ViewBag.Services = new SelectList(await this.serviceRepo.GetAll(), "ServiceID", "Title");
            if (ModelState.IsValid)
            {
                if (rec.Photo == null || rec.Photo.Length == 0)
                {
                    ModelState.AddModelError("Photo", "Please Select The Photo To Upload");
                    return View(rec);
                }
                else
                {
                    string folderpath = Path.Combine(this.env.WebRootPath, "servicephotos");
                    string filepath = Path.Combine(folderpath, rec.Photo.FileName);
                    FileStream fs = new FileStream(filepath, FileMode.Create);
                    rec.Photo.CopyTo(fs);
                    fs.Close();
                    rec.PhotoPath = "/servicephotos/" + rec.Photo.FileName;
                }

                var res = await this.ServicePhotosRepo.Update(rec);
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
            var res = await this.ServicePhotosRepo.Delete(id);
            TempData["Message"] = res.Message;
            return RedirectToAction("Index");
        }
    }
}
