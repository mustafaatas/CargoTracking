using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Cannot be empty mail field.")]
        public string Mail { get; set; }

        //[Required(ErrorMessage = "Cannot be empty username field.")]
        //public string UserName { get; set; }

        [Required(ErrorMessage = "Cannot be empty password field.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}