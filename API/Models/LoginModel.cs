using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Cannot be empty username field.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Cannot be empty password field.")]
        public string Password { get; set; }
    }
}
