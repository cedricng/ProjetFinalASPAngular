using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetFinal.DAL
{
    public class DaoCommande
    {
        public List<Commande> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Commandes.ToList<Commande>();
        }
        public Commande FindById(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Commandes.Find(id);
        }
        public Commande Create(Commande com)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Commandes.Add(com);
            context.SaveChanges();
            return com;
        }

        



        public void Delete(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            Commande com = context.Commandes.Find(id);
            context.Commandes.Remove(com);
            context.SaveChanges();
        }
        public void Update(Commande p)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();



        }
    }
}
