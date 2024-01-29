
using ProjetFinal.Models;
using ProjetFinal.Models.Clients;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace ProjetFinal.DAL
{
    public class DaoAuth
    {
        private readonly  projetfinalEntities context = new projetfinalEntities();

        public Auth SaveAuthData(Auth authData)
        {
            // Convertir AuthModel en AuthEntity
            var authEntity = new Auth
            {
                idClient = authData.idClient,
                password = authData.password,
                //ExpiryDate = authData.ExpiryDate
            };
            // Ajouter l'entité à DbContext et enregistrer les modifications dans la base de données
            context.Auths.Add(authEntity);
            context.SaveChanges();
            return authEntity;

        }
        public Auth GetAuthData(int idClient)
        {
            // Récupérer l'entité d'authentification de la base de données
            var authEntity = context.Auths.FirstOrDefault(a => a.idClient == idClient);

            // Convertir l'entité en AuthModel
            return new Auth
            {
                idClient = authEntity.idClient,
                password = authEntity.password,
                //expiryDate = authEntity.expiryDate
            };
        }

        public bool ValidateCredentials(LoginModel loginModel)
        {
            var hashedPassword = HashPassword(loginModel.Password); // Assurez-vous d'implémenter la fonction de hachage
            Client client = context.Clients.FirstOrDefault(u => u.login == loginModel.Login);
            if (client == null)
            {
                return false;
            }
            else
            {
                Auth auth = context.Auths.FirstOrDefault(u => u.idClient == client.id && u.password == hashedPassword);
                return auth != null;
            }
           
        }

        public Auth FindById(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Auths.Find(id);
        }

        public Auth FindByIdClient(int idClient)
        {
            
            projetfinalEntities context = new projetfinalEntities();
            Auth auth = context.Auths.FirstOrDefault(u => u.idClient == idClient);
            return auth;
        }

        public Auth Create(Auth auth)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Auths.Add(auth);
            context.SaveChanges();
            return auth;
        }
        public void Delete(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            Auth auth = context.Auths.Find(id);
            context.Auths.Remove(auth);
            context.SaveChanges();
        }
        public void Update(Auth auth)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Entry(auth).State = EntityState.Modified;
            context.SaveChanges();

        }
        private string HashPassword(string password)
        {
            // Implémentez la logique de hachage sécurisée ici
            // Vous devriez utiliser une bibliothèque de hachage sécurisée comme BCrypt ou Argon2
            return password; 
        }

    }
}