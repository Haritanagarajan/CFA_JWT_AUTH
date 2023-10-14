using CFA_JWT_AUTH.IRepository;
using CFA_JWT_AUTH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CFA_JWT_AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AuthUserInfoController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IUser _user;
        public AuthUserInfoController(IUser user, UserDbContext context)
        {
            _user = user;
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserDetailsModel>>> GetUserDetails()
        {
            try
            {
                var authinfo = await _user.GetUserDetails();
                return Ok(authinfo);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred While fetching your details.");
            }
        }
    }
}
