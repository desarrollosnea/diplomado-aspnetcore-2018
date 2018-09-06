using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Prode.Servicios.Models;

namespace Prode.Servicios.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]    
        [HttpPost]
        public IActionResult Get([FromBody] TokenRequest tokenRequest)
        {
            if (IsValid(tokenRequest))
            { 
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, tokenRequest.Username)
                };

                //Get config
                //TODO: Encapsulate into component and shared cross project
                var secret = _configuration["Auth:Secret"];
                var issuer = _configuration["Auth:Issuer"];
                var audience = _configuration["Auth:Audience"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                            issuer: issuer,     //"http://localhost:9100"
                            audience: audience, //"StarWarsAPI"
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: credentials);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Invalid Username or password");
        }

        

        private bool IsValid(TokenRequest tokenRequest) {
            if (tokenRequest == null)
                return false;

            return tokenRequest.Username == Reverse(tokenRequest.Password);
        }

        private string Reverse(string cadena)
        {
            char[] charArray = cadena.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
