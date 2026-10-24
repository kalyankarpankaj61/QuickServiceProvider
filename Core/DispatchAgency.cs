using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DispatchAgency
    {
        public Int64 DispatchAgencyID { get; set; }
        public string DispatchAgencyName { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string ContactPersonName { get; set; }
        public virtual List<OrderDispatch> OrderDispatches { get; set; }

    }
}
