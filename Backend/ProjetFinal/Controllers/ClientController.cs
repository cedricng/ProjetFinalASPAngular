using ProjetFinal.DAL;
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
            return new DaoClient().FindByLogin(login);
        }

        /*// GET: api/Client/
        public clients GetPost([FromBody]string login)
        {
            return new DaoClient().FindByLogin(login);
        }*/

        // POST: api/Client
        public void Post([FromBody]Client value)
        {
            new DaoClient().Create(value);

        }

        // PUT: api/Client
        public void Put([FromBody]Client value)
        {
            new DaoClient().Update(value);
        }

        // DELETE: api/Client/?login=pseudo
        public void Delete(string login)
        {
            new DaoClient().Delete(login);
        }

        /*// DELETE: api/Client/
        public void DeletePost([FromBody]string login)
        {
            new DaoClient().Delete(login);
        }*/
    }
}
