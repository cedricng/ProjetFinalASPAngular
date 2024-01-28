using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetFinal.DAL
{
    public class DaoClient
    {
        public List<Client> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Clients.ToList();
        }
        public Client FindByLogin(string login)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Clients.Find(login);
        }
        public Client Create(Client cli)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Clients.Add(cli);
            context.SaveChanges();
            return cli;
        }


        public void Delete(string login)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client cli = context.Clients.Find(login);
            context.Clients.Remove(cli);
            context.SaveChanges();
        }
        public void Update(Client cli)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Entry(cli).State = EntityState.Modified;
            context.SaveChanges();



        }
    }
}