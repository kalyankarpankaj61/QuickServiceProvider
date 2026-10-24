using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User
    {
        public Int64 UserID {  get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo  { get; set; }
        public string Password { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
