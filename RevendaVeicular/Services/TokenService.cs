using Microsoft.IdentityModel.Tokens;
using RevendaVeicular.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace RevendaVeicular.Services
{
    public class TokenService
    {
        public static object GenerateToken(EmployerModel employerModel)
        {
            //Chamando o método estático da classe Key
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("Role", employerModel.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);
            return new
            {
                token = tokenString
            };
        }
    }
}
