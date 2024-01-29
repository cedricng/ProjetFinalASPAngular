using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinal.Services.Utils
{
    public class Helpers
    {
        public static string HashPassword(string password)
        {
            // Implémentez la logique de hachage sécurisée ici
            // Vous devriez utiliser une bibliothèque de hachage sécurisée comme BCrypt ou Argon2
            return password; // Ceci est un exemple simplifié, NE PAS utiliser dans un environnement de production réel
        }

        // Méthode pour vérifier si le mot de passe est correct
        private static bool VerifyPassword(string enteredPassword, string actualPassword)
        {
            // Implémentez votre logique de vérification de mot de passe ici (hashage, comparaison, etc.)
            // Dans cet exemple, nous supposons une comparaison simple pour illustrer le concept
            return enteredPassword == actualPassword;
        }
    }
}