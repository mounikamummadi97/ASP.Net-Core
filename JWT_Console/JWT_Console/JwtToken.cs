using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Console
{
    public class JwtToken
    {
        public void TokenGeneration()
        {
            //The secret key
            var secretKey = "MyAuthentication";

            //The header 
            var header = new JwtHeader(new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256));
            //the payload
            Console.WriteLine("Enter UserName");
            var name=Console.ReadLine();
            Console.WriteLine("Enter EmailAddress");
            var email = Console.ReadLine();
            var issuer = "facebookIssuer";
            var audience = "instagramAudience";
            var claims = new List<Claim>();
            claims.Add(new Claim("Name", $"{name}"));
            claims.Add(new Claim("Email",$"{email}"));
            var startTime = DateTime.Now;
            var endTime = DateTime.Now.AddMinutes(5);
            var payload = new JwtPayload(issuer,audience, claims,startTime, endTime);
            //Create the jwt
            var jwt = new JwtSecurityToken(header, payload);

            //Encode the JWT as a string
            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            Console.WriteLine(encodeJwt);

        }
    }
}
