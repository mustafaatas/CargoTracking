using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : BaseApiController
    {  
        [HttpPost]
        public ActionResult<bool> SignIn([FromBody]AccountDto input)
        {
            var mail = "atasmustafa2000@gmail.com";
            var password = "123qwe";


            if (input.Password != password)
            {
                return BadRequest("Wrong password");
            }
            if (input.Mail != mail)
            {
                return BadRequest("Wrong mail");
            }

            if (input == null)
            {
                return BadRequest("Cannot be empty");
            }

            return true;
        }
    }
}
