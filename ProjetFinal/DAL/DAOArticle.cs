using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetFinal.DAL
{
    public class DAOArticle
    {
        public List<articles> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.articles.ToList<articles>();
        }
        public articles FindById(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.articles.Find(id);
        }
        public articles Create(articles p)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.articles.Add(p);
            context.SaveChanges();
            return p;
        }

        public List<articles> FindByPrixMinMax(int min, int max)
        {
            projetfinalEntities context = new projetfinalEntities();

            return context.articles.Where(a => a.prix >= min && a.prix <= max).OrderBy(a => a.prix).ToList();
        }

        

        public void Delete(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            articles p = context.articles.Find(id);
            context.articles.Remove(p);
            context.SaveChanges();
        }
        public void Update(articles p)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();



        }
    }
}