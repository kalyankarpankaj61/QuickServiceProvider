using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class OrderDispatch
    {
        public Int64 OrderDispatchID { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime ExpectedReachDate { get; set; }
        public string DocketNo { get; set; }
        public Int64 OrderID { get; set; }
        public virtual Order Order { get; set; }
        public Int64 DispatchAgencyID { get; set; }
        public virtual DispatchAgency DispatchAgency { get; set; }

    }
}
