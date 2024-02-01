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
                Clients client = GetClientByUsername(login.username);

                // Générez le token JWT après une connexion réussie
                var response = Mapper.Map<LoginResponse>(client);
                response.token = JwtManager.GenerateToken(client);
                return response;
            }

            // Retournez null ou une indication d'échec de connexion, selon vos besoins
            throw new BadRequestException("Username or password is incorrect");
        }

        public string Register(RegisterRequest registerRequest)
        {
            Clients client = GetClientByUsername(registerRequest.username);
            if (client != null)
            {
                throw new BadRequestException("User already found: " + registerRequest.username);
                //return BadRequest("User already found: " + registerModel.username);
            }
            // map model to new user object
            Clients newClient = Mapper.Map<Clients>(registerRequest);
            // hash password

            //newClient.password = HashPassword(registerModel.password);
            DaoClient daoClient = new DaoClient();
            daoClient.Create(newClient);

            return JwtManager.GenerateToken(newClient);
        }


        public List<Clients> GetAllClients()
        {
            DaoClient daoClient = new DaoClient();
            return daoClient.FindAll();
        }

        public Clients GetClientById(int id)
        {
            DaoClient daoClient = new DaoClient();
            return daoClient.FindById(id);

        }

        public Clients GetClientByUsername(string username)
        {
            DaoClient daoClient = new DaoClient();
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
            DaoClient daoClient = new DaoClient();

            Clients cli = daoClient.FindByLoginAndPassword(loginModel);
            return (cli != null);
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