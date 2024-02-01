using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ProjetFinal.DAL;
using ProjetFinal.Models.Clients;
using ProjetFinal.Helpers;
using System.Text;

namespace ProjetFinal.Helpers
{


    public class JwtManager
    {
        private const string SecretKey =  "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
        private static readonly SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecretKey));


        public static string GenerateTokenForLogin(Clients client)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, client.username),
            new Claim(ClaimTypes.NameIdentifier, client.username),
            new Claim(ClaimTypes.Role, client.role),

            new Claim(ClaimTypes.GivenName, client.nom),
            new Claim(ClaimTypes.Surname, client.prenom),
            new Claim(ClaimTypes.Email, client.mail),
            new Claim(ClaimTypes.Role, client.role),
            // Ajoutez d'autres claims selon vos besoins
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Durée de validité du token
                SigningCredentials = new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static string GenerateTokenForRegistration(Clients client)
        {
            // Vous pouvez personnaliser les claims selon vos besoins lors de l'inscription
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, client.username),
            new Claim(ClaimTypes.NameIdentifier, client.username),
            new Claim(ClaimTypes.Role, client.role),

            new Claim(ClaimTypes.GivenName, client.nom),
            new Claim(ClaimTypes.Surname, client.prenom),
            new Claim(ClaimTypes.Email, client.mail),
            new Claim(ClaimTypes.Role, client.role),
            // Ajoutez d'autres claims selon vos besoins
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Durée de validité du token
                SigningCredentials = new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static ClaimsPrincipal ValidToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = SigningKey,
                ValidIssuer = "your_issuer",
                ValidAudience = "your_audience",
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            return tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        }
        public static string GenerateToken(Clients client)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("id", client.id.ToString()),
                    new Claim("username", client.username),
                    new Claim("role", client.role),
                    new Claim("nom", client.nom),
                    new Claim("prenom", client.prenom),
                    new Claim("mail", client.mail),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var clientId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return clientId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
