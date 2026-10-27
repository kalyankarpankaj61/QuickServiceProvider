using Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public interface ICompanyRepo
    {
        Task<LoginResultDto> Login(LoginDto rec);
    }
}
