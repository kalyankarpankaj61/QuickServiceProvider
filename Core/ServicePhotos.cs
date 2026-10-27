using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ServicePhotos
    {
        public Int64 ServicePhotosID { get; set; }
        public string PhotoPath { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime UploadedDate { get; set; }
        public Int64 ServiceID { get; set; }
        public virtual Service service { get; set; }
    }
}
