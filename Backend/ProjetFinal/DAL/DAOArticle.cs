using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetFinal.DAL
{
    public class DaoArticle
    {
        public List<Articles> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Articles.ToList();
        }
        public Articles FindById(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Articles.Find(id);
        }
        public Articles Create(Articles art)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Articles.Add(art);
            context.SaveChanges();
            return art;
        }

        public List<Articles> FindByPrixMinMax(int min, int max)
        {
            projetfinalEntities context = new projetfinalEntities();

            return context.Articles.Where(a => a.prix >= min && a.prix <= max).OrderBy(a => a.prix).ToList();
        }

        

        public void Delete(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            Articles art = context.Articles.Find(id);
            context.Articles.Remove(art);
            context.SaveChanges();
        }
        public void Update(Articles art)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Entry(art).State = EntityState.Modified;
            context.SaveChanges();



        }
    }
}