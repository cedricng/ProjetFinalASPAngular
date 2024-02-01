using AutoMapper;
using ProjetFinal.Helpers;
using ProjetFinal.Models.Clients;
using ProjetFinal.Models.Token;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Deployment.Internal;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace ProjetFinal.DAL
{
    public class DaoClient
    {
        private readonly projetfinalEntities contextT = new projetfinalEntities();

        public List<Clients> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Clients.ToList();
        }

        public Clients FindById(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Clients.Find(id);
        }
        public Clients FindByUsername(string username)
        {
            projetfinalEntities context = new projetfinalEntities();
            Clients client = context.Clients.FirstOrDefault(u => u.username == username);
            return client;
        }
        public Clients FindByMail(string mail)
        {
            projetfinalEntities context = new projetfinalEntities();
            Clients client = context.Clients.FirstOrDefault(u => u.mail == mail);
            return client;
        }

        public Clients FindByUsernameOrMail(string input)
        {
            Clients client = (input.Contains("@")) ? FindByMail(input) : FindByUsername(input);
            return client;
        }

        public Clients FindByLoginAndPassword(LoginRequest loginModel)
        {
            projetfinalEntities context = new projetfinalEntities();
            //string hashedPassword = HashPassword(loginModel.password);
            return context.Clients.FirstOrDefault(u => u.username == loginModel.username && u.password == loginModel.password);
        }


        public Clients Create(Clients client)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Clients.Add(client);
            context.SaveChanges();
            return client;
        }

        public void DeleteByUsername(string username)
        {
            projetfinalEntities context = new projetfinalEntities();
            Clients cli = FindByUsername(username);
            context.Clients.Remove(cli);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            Clients cli = context.Clients.Find(id);
            context.Clients.Remove(cli);
            context.SaveChanges();
        }
        public void Update(UpdateRequest req)
        {
            projetfinalEntities context = new projetfinalEntities();
            Clients client = Mapper.Map<Clients>(req);
            context.Entry(client).State = EntityState.Modified;
            context.SaveChanges();


        }
        public void UpdateById(int id, UpdateRequest updateRequest)
        {
            projetfinalEntities context = new projetfinalEntities();
            Clients a = context.Clients.Find(id);
            if(a != null)
            {
                Clients client = Mapper.Map<Clients>(updateRequest);
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
 
        }
        public void UpdateByUsername(string username)
        {
            projetfinalEntities context = new projetfinalEntities();
            Clients client = FindByUsername(username);
            context.Entry(client).State = EntityState.Modified;
            context.SaveChanges();

        }

    }
}