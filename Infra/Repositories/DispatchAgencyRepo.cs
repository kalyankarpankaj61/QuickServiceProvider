using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class DispatchAgencyRepo : GenericRepo<DispatchAgency>, IDispatchAgencyRepo
    {
        CompanyContext cc;

        public DispatchAgencyRepo(CompanyContext cc) : base(cc)
        {
            this.cc = cc;
        }
    }
}
