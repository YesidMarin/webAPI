using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiRest.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _repositoryWrapper;

        public UserController(IUserService repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = _repositoryWrapper.Authenticate(userParam.Username, userParam.Password);

                if (user == null)
                {
                    return BadRequest(new { message = "user or pass is incorrect" });
                }

                return Ok(user);
            } catch (Exception ex)
            {
                return StatusCode(500, "internal error");
            }

        }
    }
}
