using ProjetFinal.DAL;
using ProjetFinal.Models.Clients;
using ProjetFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjetFinal.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IEnumerable<Client> Get()
        {
            return new DaoClient().FindAll();

        }

        // GET: api/Client/?login=pseudo
        public Client Get(string login)
        {
            return ClientService.GetClientByLogin(login);
            //return new DaoClient().FindByLogin(login);
        }

        /*// GET: api/Client/
        public clients GetPost([FromBody]string login)
        {
            return new DaoClient().FindByLogin(login);
        }*/



        // PUT: api/Client
        public void Put([FromBody] Client value)
        {
            new DaoClient().Update(value);
        }

        // DELETE: api/Client/?login=pseudo
        public void Delete(string login)
        {
            new DaoClient().DeleteByLogin(login);
        }

        /*// DELETE: api/Client/
        public void DeletePost([FromBody]string login)
        {
            new DaoClient().Delete(login);
        }*/

        [HttpPost]
        [Route("api/client/login")]
        public IHttpActionResult Login([FromBody] LoginModel loginModel)
        {
            // Appelez la méthode d'authentification de votre service
            var token = ClientService.Login(loginModel);

            if (token == null)
            {
                // L'authentification a échoué
                return Unauthorized(); // 401 Unauthorized
            }

            // L'authentification a réussi, retournez le token JWT
            return Ok(new { Token = token });
        }


        [HttpPost]
        [Route("api/client/register")]
        public IHttpActionResult Register([FromBody] Client value)
        {
            // Appelez la méthode d'inscription de votre service
            ClientService.Register(value);

            // L'inscription a réussi, retournez une réponse réussie
            return Ok("Registration successful");
        }
    }
}
        