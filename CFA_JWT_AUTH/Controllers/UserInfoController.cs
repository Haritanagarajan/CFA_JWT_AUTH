using CFA_API.CustomAuthorize;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using UserManagement.Data.IRepository;
using UserManagement.Data.Models;

namespace CFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IUser _user;
        public UserInfoController(IUser user, UserDbContext context)
        {
            _user = user;
            _context = context;
        }
        [Block]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetailsModel>>> GetUserDetails()
        {
            try
            {
               
                var userinfo = await _user.GetUserDetails();
                return Ok(userinfo);
            }
            catch (Exception)
            {
                return StatusCode(404, "An error occurred While fetching your details.");
            }
        }
    }
}

