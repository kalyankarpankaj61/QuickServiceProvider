using Core;
using Infra.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class SubCategoryRepo : GenericRepo<SubCategory>, ISubCategoryRepo
    {
        CompanyContext cc;

        public SubCategoryRepo(CompanyContext cc) : base(cc)
        {
            this.cc = cc;
        }

        public async Task<List<SubCategoryDto>> GetByMainCategories(long mainCategoryID)
        {
            var res = await (from t in this.cc.subCategories 
                             where t.MainCategoryID==mainCategoryID
                             select new SubCategoryDto
                             {
                                 SubCategoryId=t.SubCategoryID,
                                 SubCategoryName=t.SubCategoryName
                             }).ToListAsync();
            return res;
        }
    }
}
 