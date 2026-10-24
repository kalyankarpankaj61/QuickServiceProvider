using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Service
    {
        public Int64 ServiceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Charges { get; set; }
        public Int64 SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public ChargesTypeEnum ChargesType { get; set; }
        public virtual List<ServicePhotos> servicephotos { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
