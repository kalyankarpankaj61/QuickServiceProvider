using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Order
    {
        public Int64 OrderID { get; set; }
        public String OrderName { get; set; }
        public Int64 UserID { get; set; }
        public virtual User User { get; set; }
        public bool IsPaid { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<OrderDispatch> OrderDispatches { get; set; }
    }
}
