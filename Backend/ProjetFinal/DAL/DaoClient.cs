using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetFinal.DAL
{
    public class DaoClient
    {
        public List<clients> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.clients.ToList<clients>();
        }
        public clients FindByLogin(string login)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.clients.Find(login);
        }
        public clients Create(clients p)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.clients.Add(p);
            context.SaveChanges();
            return p;
        }





        public void Delete(string login)
        {
            projetfinalEntities context = new projetfinalEntities();
            clients p = context.clients.Find(login);
            context.clients.Remove(p);
            context.SaveChanges();
        }
        public void Update(clients p)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();



        }
    }
}