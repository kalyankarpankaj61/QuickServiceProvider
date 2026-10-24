using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SubCategory
    {
        public Int64 SubCategoryID {  get; set; }
        public string SubCategoryName { get; set; }
        public Int64 MainCategoryID { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public virtual List<Service> services { get; set; }
    }
}
