using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieSite.DAL;
using MovieSite.Entity;
using MovieSite.UOW;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MovieSite.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        

        string signinKey = "Bubenimgizlianahtarim";
       

        [HttpGet]
        public string Get(string userName, string password)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(JwtRegisteredClaimNames.Email,userName)
            };


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurtyToken = new JwtSecurityToken(
               issuer: "http://localhost",
               audience: "http://localhost",   //????
               claims: claims,
               expires: DateTime.Now.AddDays(10),
               notBefore: DateTime.Now,
               signingCredentials: credentials);


            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurtyToken);
            return token;
        }


        [HttpGet("ValidateToken")]
        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = jwtToken.Claims.ToList();
                return true;

            }
            catch (System.Exception)
            {

                return false;
            }
        }

    }
}
