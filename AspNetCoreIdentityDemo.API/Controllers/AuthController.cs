using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentityDemo.API.Services;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityDemo.Shared;

namespace AspNetCoreIdentityDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService; 

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        // /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewMolel model){
            if(ModelState.IsValid){

                var result = await _userService.RegisterUserAsync(model);

                if(result.IsSuccess){
                    return Ok(result); // Status Code successfully : 200
                }

                return BadRequest(result);
            }


            return BadRequest("Some properties are not valid"); // Status code : 400
        }
    }
}