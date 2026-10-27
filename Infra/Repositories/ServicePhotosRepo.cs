using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ServicePhotosRepo : GenericRepo<ServicePhotos>,IServicePhotosRepo
    {
        CompanyContext cc;

        public ServicePhotosRepo(CompanyContext cc) : base(cc)
        {
            this.cc = cc;
        }
    }
}
