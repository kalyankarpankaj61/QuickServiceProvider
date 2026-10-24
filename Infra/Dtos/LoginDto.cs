using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Email Id Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Id")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Password required")]
        
        public string Password { get; set; }
    }
}
