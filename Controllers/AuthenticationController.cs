using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Models;
using Techno_Project.Repos;

namespace Techno_Project.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        IAuthentication IAuth;
        public AuthenticationController(IAuthentication _IAuth)
        {
            IAuth = _IAuth;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] Authentication Authentication)
        {
            try
            {
                var found = await IAuth.Login(Authentication);
                if(found==false)
                {
                    return StatusCode(404, "User Not Found ...Please Try again");
                }
                else
                {
                    return Ok(1);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(404, "There was a problem Login Process . Please try again.");
            }
           
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register([FromBody] Authentication Authentication)
        {
            try
            {
                var formid = await IAuth.Register(Authentication);
                if(formid)
                {
                    return Ok(1);
                }
                else
                {
                    return StatusCode(404, "There was a problem saving record in the database. Please try again.");
                }
            }
            catch(Exception e)
            {
                return StatusCode(404, "There was a problem saving record in the database. Please try again.");
            }
          

        }
    }
}
