using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinal.Helpers
{
    public class PasswordHasher
    {
        public string HashPassword(string plainTextPassword)
        {
            // Générer un sel
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12); // Vous pouvez ajuster le facteur de coût (logarithmique) selon vos besoins

            // Hacher le mot de passe avec le sel généré
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainTextPassword, salt);

            return hashedPassword;
        }

        public bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            // Vérifier le mot de passe saisi par rapport au hachage stocké
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
        }
    }
}