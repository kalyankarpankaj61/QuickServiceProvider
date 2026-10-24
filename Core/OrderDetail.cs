using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class OrderDetail
    {
        public Int64 OrderDetailID { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public Int64 OrderID { get; set; }
        public virtual Order Order { get; set; }
        public Int64 ServiceID { get; set; }
        public virtual Service Service { get; set; }
    }
}
