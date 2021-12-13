using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidatePasswordPattern.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ValidatePasswordPattern.Api.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] UserModel user)
        {
            if (ModelState.IsValid)
            {
                return Ok();//new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
                return BadRequest(ModelState);
        }
    }            
}

