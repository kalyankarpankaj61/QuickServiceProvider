using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ServicePhotos
    {
        public Int64 ServicePhotosID { get; set; }
        public string PhotoPath { get; set; }
        public DateTime UploadedDate { get; set; }
        public Int64 ServiceID { get; set; }
        public virtual Service service { get; set; }
    }
}
