using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CFA_JWT_AUTH.Models;
using CFA_JWT_AUTH.IRepository;

namespace CFA_JWT_AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IUser _user;
        public UserRegistrationController(IUser user, UserDbContext context)
        {
            _user = user;
            _context = context;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDetailsModel>> PostUserDetailsModel([FromForm] UserDetailsModel userDetailsModel)
        {
            try
            {
                await _user.PostUserDetailsModel(userDetailsModel);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred While registering your details.");
            }
        }
    }
}
