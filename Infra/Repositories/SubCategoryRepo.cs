using Core;
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
    }
}
 