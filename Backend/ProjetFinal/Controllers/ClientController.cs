using AutoMapper;
using ProjetFinal.DAL;
using ProjetFinal.Helpers;
using ProjetFinal.Models.Clients;
using ProjetFinal.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel;
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
      
        [HttpPost]
        [Route("api/Client/login")]
        public IHttpActionResult Login([FromBody] LoginRequest loginModel)
        {
            // Appelez la méthode d'authentification de votre service
            ClientService clientService = new ClientService();
            var reponse = clientService.Login(loginModel);


            // L'authentification a réussi
            return Ok(reponse);
        }


        [HttpPost]
        [Route("api/Client/register")]
        public IHttpActionResult Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                // Appelez la méthode d'inscription de votre service
                ClientService clientServ = new ClientService();
                clientServ.Register(registerRequest);

                // L'inscription a réussi, retournez une réponse réussie
                return Ok("Registration successful");
            }
            catch (BadRequestException ex)
            {
                // Gérer le cas où l'utilisateur existe déjà
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Gérer d'autres erreurs
                return InternalServerError(ex);
            }
        }

        // GET: api/Client
        [HttpGet]
        public IEnumerable<Clients> Get()
        {
            ClientService clientService = new ClientService();

            //return new DaoClient().FindAll();
            return clientService.GetAllClients();
        }

        // GET: api/Client/?login=pseudo
        //[HttpGet]
        //[Route("api/Client/?username=pseudo")]
        public Clients GetClientByUsername(string username)
        {
            ClientService clientService = new ClientService();

            return clientService.GetClientByUsername(username);
            //return new DaoClient().FindByLogin(login);
        }


        // GET: api/Client/5
        //[HttpGet]
        //[Route("api/Client/{id}")]
        public Clients Get(int id)
        {
            ClientService clientService = new ClientService();

            return clientService.GetClientById(id);
        }

        /*
        // PUT: api/Client
        public void Put(int id, UpdateRequest model)
        {
             clientService.Update(id, model);
        return Ok(new { message = "User updated successfully" });
        } */


        // DELETE: api/Client/5
        public void Delete(int id)
        {
            new DaoClient().Delete(id);
        }


        // DELETE: api/Client/?login=pseudo
        public void Delete(string username)
        {
            new DaoClient().DeleteByUsername(username);
        }




        /*// GET: api/Client/
        public clients GetPost([FromBody]string login)
        {
            return new DaoClient().FindByLogin(login);
        }*/








    }
}
