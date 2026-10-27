using Infra.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CompanyRepo : ICompanyRepo
    {
        CompanyContext cc;
        public CompanyRepo(CompanyContext cc)
        {
            this.cc = cc;
        }

        public async Task<LoginResultDto> Login(LoginDto rec)
        {
            LoginResultDto res= new LoginResultDto();
            var urec= await this.cc.serviceProvidersCompany.SingleOrDefaultAsync(p=>p.EmailId==rec.EmailId && p.Password==rec.Password);
            if(urec != null)
            {
                res.IsLoggedIn = true;
                res.LoggedInCompanyId=urec.ServiceProviderCompanyID;
                res.LoggedInName=urec.ServiceProviderCompanyName;
                
            }
            else
            {
                res.IsLoggedIn = false;
                res.Message = "Invalid EmalilId Or Password";
            }
            return res;
        }
    }
}
