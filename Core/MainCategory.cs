using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MainCategory
    {
        public Int64 MainCategoryID { get; set; }
        public string MainCategorynName { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
