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

        public List<Client> FindAll()
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Clients.ToList();
        }

        public Client FindById(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            return context.Clients.Find(id);
        }
        public Client FindByUsername(string username)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client client = context.Clients.FirstOrDefault(u => u.username == username);
            return client;
        }
        public Client FindByMail(string mail)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client client = context.Clients.FirstOrDefault(u => u.mail == mail);
            return client;
        }

        public Client FindByUsernameOrMail(string input)
        {
            Client client = (input.Contains("@")) ? FindByMail(input) : FindByUsername(input);
            return client;
        }

        public Client FindByLoginAndPassword(LoginRequest loginModel)
        {
            projetfinalEntities context = new projetfinalEntities();
            //string hashedPassword = HashPassword(loginModel.password);
            return context.Clients.FirstOrDefault(u => u.username == loginModel.username && u.password == loginModel.password);
        }


        public Client Create(Client client)
        {
            projetfinalEntities context = new projetfinalEntities();
            context.Clients.Add(client);
            context.SaveChanges();
            return client;
        }

        public void DeleteByUsername(string username)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client cli = FindByUsername(username);
            context.Clients.Remove(cli);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client cli = context.Clients.Find(id);
            context.Clients.Remove(cli);
            context.SaveChanges();
        }
        public void Update(UpdateRequest req)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client client = Mapper.Map<Client>(req);
            context.Entry(client).State = EntityState.Modified;
            context.SaveChanges();


        }
        public void UpdateById(int id, UpdateRequest updateRequest)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client a = context.Clients.Find(id);
            if(a != null)
            {
                Client client = Mapper.Map<Client>(updateRequest);
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
 
        }
        public void UpdateByUsername(string username)
        {
            projetfinalEntities context = new projetfinalEntities();
            Client client = FindByUsername(username);
            context.Entry(client).State = EntityState.Modified;
            context.SaveChanges();

        }

    }
}