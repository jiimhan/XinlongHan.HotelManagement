using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;
using XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace XinlongHan.HotelManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var createUser = await _userService.RegisterUser(model);
                // 201 created code
                return Ok();
            }
            // 400
            return BadRequest("Please check the data your enterd");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            // check un/pw is correct
            var user = await _userService.Login(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var jwt = CreateJWT(user);
            // user entered correct password
            // we create a token JWT which includes the user information and send it to Angular application

            return Ok(new { token = jwt });
        }
        private string CreateJWT(UserLoginResponseModel model)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, model.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName),
                new Claim(JwtRegisteredClaimNames.Email, model.Email)
            };

            // create identity object and store above claims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // read the secret key from the app.settings.json, make sure secret key is unique and non guessable
            // In real world we dont store these secret keys in appsettings, we use something like Azure KeyVault

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MovieShopSecretKey"]));

            //pick a builtin algorithm for hashing

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // establish the expiration time for the token

            var expires = DateTime.Now.AddDays(_configuration.GetValue<int>("ExpirationDuration"));

            var tokenHandler = new JwtSecurityTokenHandler();

            // create a object that's gonna store all the above information

            var tokenObject = new SecurityTokenDescriptor()
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["MovieShopIssuer"],
                Audience = _configuration["MovieShopAudience"]
            };

            var encodedJwt = tokenHandler.CreateToken(tokenObject);
            return tokenHandler.WriteToken(encodedJwt);
        }
    }
}
