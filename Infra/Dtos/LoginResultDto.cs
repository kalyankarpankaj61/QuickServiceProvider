using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dtos
{
    public class LoginResultDto
    {
        public string LoggedInName { get; set; }
        public Int64 LoggedInCompanyId { get; set; }
        public bool IsLoggedIn { get; set; }
        public string Message {  get; set; }
    }
}
