using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CommonAjaxController : Controller
    {
        ISubCategoryRepo subCategoryRepo;
        public CommonAjaxController(ISubCategoryRepo subCategoryRepo)
        {
            this.subCategoryRepo = subCategoryRepo;
        }

        public async Task<JsonResult> GetSubCategories(Int64 id)
        {
            var res= await this.subCategoryRepo.GetByMainCategories(id);
            return Json(res);
        }
    }
}
