using AutoMapper;
using ProjetFinal.DAL;
using ProjetFinal.Helpers;
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
        private ClientService clientService;

        public ClientController(ClientService _clientService)
        {
            clientService = _clientService;
        }
        [HttpPost]
        [Route("api/Client/login")]
        public IHttpActionResult Login([FromBody] LoginRequest loginModel)
        {
            // Appelez la méthode d'authentification de votre service
            var reponse = clientService.Login(loginModel);

            // L'authentification a réussi
            return Ok(reponse);
        }


        [HttpPost]
        [Route("api/Client/register")]
        public IHttpActionResult Register([FromBody] RegisterRequest value)
        {
            // Appelez la méthode d'inscription de votre service
            clientService.Register(value);

            // L'inscription a réussi, retournez une réponse réussie
            return Ok("Registration successful");
        }

        // GET: api/Client
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            //return new DaoClient().FindAll();
            return clientService.GetAllClients();
        }

        // GET: api/Client/?login=pseudo
        //[HttpGet]
        //[Route("api/Client/?username=pseudo")]
        public Client GetClientByUsername(string username)
        {
            return clientService.GetClientByUsername(username);
            //return new DaoClient().FindByLogin(login);
        }


        // GET: api/Client/5
        //[HttpGet]
        //[Route("api/Client/{id}")]
        public Client Get(int id)
        {
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
