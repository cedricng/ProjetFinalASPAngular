using ProjetFinal.DAL;
using ProjetFinal.Models;
using ProjetFinal.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjetFinal.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class AuthController : ApiController
    {
        private readonly DaoAuth daoAuth;

        public AuthController(DaoAuth daoAuth)
        {
            this.daoAuth = daoAuth;
        }
        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }

        // DELETE: api/Auth/login
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginModel model)
        {
            // Logique pour traiter l'authentification
            // Générez un token si les informations d'identification sont valides
            return null;



        }
    }
}
