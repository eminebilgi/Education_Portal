using BusinessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducationPortal.Controllers

{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUsersService _userService;
        public AuthController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null) { return BadRequest("Invalid"); }
            else
            {
                int userID = 0;
                if (loginDto.UserType == "member")
                {
                    userID = _userService.MemberLogin(loginDto.Email, loginDto.Password).Result;
                }
                else if (loginDto.UserType == "trainer")
                {
                    userID = _userService.TrainerLogin(loginDto.Email, loginDto.Password).Result;
                }

                if (userID != 0)
                {
                    SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, userID.ToString())
                    };

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5234",
                        audience: "http://localhost:5234",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new AuthenticatedResponse { Token = tokenString });
                }
            }
            return Unauthorized();
        }
    }
}

