using Azure;
using UserManagement.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CFA_JWT_AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSigninController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UserSigninController(UserDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<UserDetailsModel>> UserSignin([FromForm] SigninModel signin)
        {
            try
            {
                var user = await _context.UserDetails
                .FirstOrDefaultAsync(u => u.UserName == signin.UserName && u.UserEmail == signin.UserEmail);

                if (user != null)
                {
                    var response = new UserManagement.Data.Models.SigninModel
                    {
                        UserName = signin.UserName,
                        UserEmail = signin.UserEmail,
                    };

                    var tokenResult = TokenGenerate(response);

                    if (tokenResult is OkObjectResult okObjectResult)
                    {
                        string? jwt = okObjectResult.Value?.ToString();

                        var SigninDetails = new UserManagement.Data.Models.LoginDetails
                        {
                            UserName = response.UserName,
                            UserEmail = response.UserEmail,
                            Token = jwt
                        };
                        return Ok(SigninDetails);
                    }
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred While requesting your details.");

            }
        }
        [HttpPost("getToken")]
        public IActionResult TokenGenerate([FromBody] SigninModel user)
        {
            var key = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmksdfgbuy";
            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
              {
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim(ClaimTypes.Email, user.UserEmail),
              };
            var token = new JwtSecurityToken(
                issuer: "JWTAuthenticationServer",
                audience: "JWTServicePostmanClient",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(jwtToken);
        }
    }
}


