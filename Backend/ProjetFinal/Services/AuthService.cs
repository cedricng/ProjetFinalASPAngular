using Microsoft.Ajax.Utilities;
using ProjetFinal.DAL;
using ProjetFinal.Models.Clients;
using ProjetFinal.Models.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Net;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace ProjetFinal.Services
{
    public class AuthService
    {
        /*
        private readonly DaoAuth daoAuth;

        public AuthService(DaoAuth daoAuth)
        {
            this.daoAuth = daoAuth;
        }
        */
        private DaoAuth daoAuth;
  
            public string Login(LoginModel loginModel)
            {

                // Si l'authentification est réussie, générez un token JWT
                if (IsValidUser(loginModel))
                {
                    Client cli = GetClientByLogin(loginModel.Login);

                    // Générez le token JWT après une connexion réussie
                    return JwtManager.GenerateTokenForLogin(cli);
                }

                // Retournez null ou une indication d'échec de connexion, selon vos besoins
                return null;
            }

        public void Register(RegisterModel registerModel)
        {
            // Validez les informations de l'utilisateur, assurez-vous que le nom d'utilisateur est unique, etc.
            // Vous pouvez également hasher le mot de passe avant de le stocker.

            Client client = GetClientByLogin(registerModel.login);
            if (client != null)
            {
                throw new BadRequestException("User already found: " + registerModel.login);
            }
            
            // Enregistrez l'utilisateur dans la base de données (via le service utilisateur)
            //userService.AddUser(userModel);

            Client newClient = new Client
            {
                nom = registerModel.nom,
                prenom = registerModel.prenom,
                login = registerModel.login,
                mail = registerModel.mail,
                telephone = registerModel.telephone,
                adresse = registerModel.adresse,
                age = registerModel.age,
                role = "user"
            };

            DaoClient daoClient = null;
            DaoAuth daoAuth = null;
            Client cl = daoClient.Create(newClient);
            Auth newAuth = new Auth
            {
                idClient = cl.id,
                password = registerModel.password
            };
            daoAuth.Create(newAuth);


            // Vous pouvez également ajouter une étape pour enregistrer les informations d'authentification si nécessaire
            // authenticationDao.AddAuthentication(new Authentication { Username = userModel.Username, Password = userModel.PasswordHash });
        }

        private static bool IsValidUser(LoginModel loginModel)
            {
                DaoAuth auth = null;
                return auth.ValidateCredentials(loginModel);
            }

        private static Client GetClientByLogin(string login)
        {
            DaoClient daoClient = null;
            return daoClient.FindByLogin(login);
    
        }



    }
    }