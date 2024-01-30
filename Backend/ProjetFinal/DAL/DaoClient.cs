using ProjetFinal.Models.Clients;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Deployment.Internal;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace ProjetFinal.DAL
{
    public class DaoClient
    {
        private readonly projetfinalEntities contextT = new projetfinalEntities();

        public List<Client> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Clients.ToList();
        }
        public Client FindByLogin(string login)
        {

            projetfinalEntities context = new projetfinalEntities();
            Client cli = context.Clients.FirstOrDefault(u => u.login == login);

            return cli;
        }
        public Client FindByMail(string mail)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client cli = context.Clients.FirstOrDefault(u => u.mail == mail);

            return cli;
        }

        public Client FindByLoginOrMail(string loginOrMail)
        {
            Client cli = (loginOrMail.Contains("@")) ? FindByMail(loginOrMail) : FindByLogin(loginOrMail);
            return cli;
        }

        public Client FindByLoginAndPassword(LoginModel loginModel)
        {
            projetfinalEntities context = new projetfinalEntities();
            string hashedPassword = HashPassword(loginModel.Password);
            return context.Clients.FirstOrDefault(u => u.login == loginModel.Login && u.password == hashedPassword);
        }


        public Client Create(Client cli)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client newClient = new Client
            {
                nom = cli.nom,
                prenom = cli.prenom,
                login = cli.login,
                mail = cli.mail,
                password = cli.password,
                telephone = cli.telephone,
                adresse = cli.adresse,
                role = cli.role
            };

            context.Clients.Add(cli);
            context.SaveChanges();
            return cli;
        }

        public void DeleteByLogin(string login)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client cli = FindByLogin(login);
            context.Clients.Remove(cli);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client cli = context.Clients.Find(id);
            context.Clients.Remove(cli);
            context.SaveChanges();
        }
        public void Update(Client cli)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Entry(cli).State = EntityState.Modified;
            context.SaveChanges();

        }
        /*
        // Méthode pour enregistrer un nouvel utilisateur
        public bool RegisterUser(string login, string password)
        {
            projetfinalEntities context = new projetfinalEntities();
            // Vérifie si l'utilisateur existe déjà
            if (context.Clients.Any(u => u.login == login))
            {
                return false; // L'utilisateur existe déjà, l'inscription échoue
            }

            var hashedPassword = HashPassword(password); // Assurez-vous d'implémenter la fonction de hachage
            var newUser = new User { Username = username, Password = hashedPassword };
            AddUser(newUser);
            return true; // L'inscription a réussi
        }*/


        private string HashPassword(string password)
        {
            // Implémentez la logique de hachage sécurisée ici
            // Vous devriez utiliser une bibliothèque de hachage sécurisée comme BCrypt ou Argon2
            return password; // Ceci est un exemple simplifié, NE PAS utiliser dans un environnement de production réel
        }


    }
}