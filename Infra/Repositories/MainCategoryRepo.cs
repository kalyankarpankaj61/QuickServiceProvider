using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class MainCategoryRepo : GenericRepo<MainCategory>, IMainCategoryrepo
    {
        CompanyContext cc;

        public MainCategoryRepo( CompanyContext cc) :base(cc) 
        { 
            this.cc = cc;
        }
    }
}
