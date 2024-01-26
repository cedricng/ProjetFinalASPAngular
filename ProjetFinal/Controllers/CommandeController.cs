using ProjetFinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetFinal.Controllers
{
    public class CommandeController : ApiController
    {
        // GET: api/Commande
        public IEnumerable<Commandes> Get()
        {
            return new DaoCommande().FindAll();

        }

        



        // GET: api/Commande/5
        public Commandes Get(int id)
        {
            return new DaoCommande().FindById(id);
        }

        // POST: api/Commande
        public void Post([FromBody]Commandes value)
        {
            new DaoCommande().Create(value);

        }

        // PUT: api/Commande
        public void Put([FromBody]Commandes value)
        {
            new DaoCommande().Update(value);
        }

        // DELETE: api/Commande/5
        public void Delete(int id)
        {
            new DaoCommande().Delete(id);
        }
    }
}
