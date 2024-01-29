using ProjetFinal.DAL;
using ProjetFinal.Models.Clients;
using ProjetFinal.Models.Token;
using ProjetFinal.Services.Utils;
using System.IdentityModel;

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
        private DaoAuth daoAuth;
  
        public static string Login(LoginModel loginModel)
        {

            // Si l'authentification est réussie, générez un token JWT
            if (ValidateCredentials(loginModel))
            {
                Client cli = GetClientByLogin(loginModel.Login);

                // Générez le token JWT après une connexion réussie
                return JwtManager.GenerateTokenForLogin(cli);
            }

            // Retournez null ou une indication d'échec de connexion, selon vos besoins
            return null;
        }

        public static string Register(RegisterModel registerModel)
        {
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
                password = Helpers.HashPassword(registerModel.password),
                telephone = registerModel.telephone,
                adresse = registerModel.adresse,
                age = registerModel.age,
                role = "user"
            };

            Client cl = ((DaoClient)null).Create(newClient);
            return JwtManager.GenerateTokenForLogin(cl);
        }

        public static string Register(Client client)
        {
            Client cl = GetClientByLogin(client.login);
            if (cl != null)
            {
                throw new BadRequestException("User already found: " + client.login);
            }

            Client newClient = ((DaoClient)null).Create(client);
            return JwtManager.GenerateTokenForLogin(newClient);
        }


        public static Client GetClientByLogin(string login)
        {
            DaoClient daoClient = null;
            return daoClient.FindByLogin(login);
    
        }
        private static bool ValidateCredentials(LoginModel loginModel)
        {
            //var hashedPassword = HashPassword(loginModel.Password); // Assurez-vous d'implémenter la fonction de hachage
            // Client client = daoClient.FindByLogin(loginModel.Login);
            DaoClient daoClient = null;
            Client client = daoClient.FindByLoginAndPassword(loginModel);
            return (client != null);
        }

        public static Client GetClientEntities(RegisterModel registerModel)
        {
            Client newClient = new Client
            {
                nom = registerModel.nom,
                prenom = registerModel.prenom,
                login = registerModel.login,
                mail = registerModel.mail,
                password = Helpers.HashPassword(registerModel.password),
                telephone = registerModel.telephone,
                adresse = registerModel.adresse,
                age = registerModel.age,
                role = "user"
            };
            return newClient;
        }




    }
}