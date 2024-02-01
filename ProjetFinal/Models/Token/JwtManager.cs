using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ProjetFinal.DAL;
using ProjetFinal.Models.Clients;

namespace ProjetFinal.Models.Token
{


    public class JwtManager
    {
        private const string SecretKey = "your_secret_key";
        private static readonly SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecretKey));

        public static string GenerateTokenForLogin(ProjetFinal.DAL.Clients client)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, client.login),
            new Claim(ClaimTypes.NameIdentifier, client.login),
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

        public static string GenerateTokenForRegistration(ProjetFinal.DAL.Clients client)
        {
            // Vous pouvez personnaliser les claims selon vos besoins lors de l'inscription
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, client.login),
            new Claim(ClaimTypes.NameIdentifier, client.login),
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

        public static ClaimsPrincipal ValidateToken(string token)
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
    }

}