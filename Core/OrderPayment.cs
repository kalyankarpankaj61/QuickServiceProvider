using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class OrderPayment
    {
        public Int64 OrderPaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public Int64 OrderID {  get; set; }
        public virtual Order Order { get; set; }
        public PaymentModeEnum PaymentMode { get; set; }
    }
}
