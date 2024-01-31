using AutoMapper;
using ProjetFinal.DAL;
using ProjetFinal.Helpers;
using ProjetFinal.Models.Clients;
using ProjetFinal.Models.Token;
using ProjetFinal.Services.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Web.Helpers;
using WebGrease.Css.Ast;

namespace ProjetFinal.Services
{
    public class ClientService
    {
        /*
        private readonly DaoAuth daoAuth;

        public AuthService(DaoAuth daoAuth)
        {
            this.daoAuth = daoAuth;
        }
        */

        public LoginResponse Login(LoginRequest login)
        {

            if (ValidateCredentials(login))
            {
                Client client = GetClientByUsername(login.username);

                // Générez le token JWT après une connexion réussie
                var response = Mapper.Map<LoginResponse>(client);
                response.token = JwtManager.GenerateToken(client);
                return response;
            }

            // Retournez null ou une indication d'échec de connexion, selon vos besoins
            throw new BadRequestException("Username or password is incorrect");
        }

        public string Register(RegisterRequest registerModel)
        {
            Client client = GetClientByUsername(registerModel.username);
            if (client != null)
            {
                throw new BadRequestException("User already found: " + registerModel.username);
            }

            // map model to new user object
            Client newClient = Mapper.Map<Client>(registerModel);
            // hash password
            newClient.password = HashPassword(registerModel.password);
            Client cl = ((DaoClient)null).Create(newClient);
            return JwtManager.GenerateToken(cl);
        }

        public List<Client> GetAllClients()
        {
            DaoClient daoClient = null;
            return daoClient.FindAll();
        }

        public Client GetClientById(int id)
        {
            DaoClient daoClient = null;
            return daoClient.FindById(id);

        }

        public Client GetClientByUsername(string username)
        {
            DaoClient daoClient = null;
            return daoClient.FindByUsername(username);

        }
        /*
        public void Update(int id, UpdateRequest model)
        {
            Client c = GetClientById(id);

            // validate
            if (model.username != c.username && GetClientByUsername(model.username) != null)
                throw new AppException("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        */

        private static bool ValidateCredentials(LoginRequest loginModel)
        {
            //BCrypt.Verify(model.Password, client.PasswordHash)
            //var hashedPassword = HashPassword(loginModel.Password); // Assurez-vous d'implémenter la fonction de hachage
            DaoClient daoClient = null;
            Client cli = daoClient.FindByUsername(loginModel.username);
            PasswordHasher hash = new PasswordHasher();
            if (cli != null && hash.VerifyPassword(loginModel.password, cli.password))
                return true;
            return false;
        }

        private static string HashPassword(string password)
        {
            // Implémentez la logique de hachage sécurisée ici
            // Vous devriez utiliser une bibliothèque de hachage sécurisée comme BCrypt ou Argon2
            PasswordHasher passwordHasher = new PasswordHasher();

            // Hacher un mot de passe
            string hashedPassword = passwordHasher.HashPassword(password);
            Console.WriteLine($"Mot de passe haché : {hashedPassword}");
            return hashedPassword;
        }




    }
}