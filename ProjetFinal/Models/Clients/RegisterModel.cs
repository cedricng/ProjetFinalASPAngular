using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinal.Models.Clients
{
    public class RegisterModel
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public string login { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string telephone { get; set; }
        public string adresse { get; set; }
        public Nullable<int> age { get; set; }
        public string role { get; set; }

        public RegisterModel(string nom, string prenom, string login, string mail, string password, string telephone, string adresse, int? age, string role="user")
        {
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.mail = mail;
            this.password = password;
            this.telephone = telephone;
            this.adresse = adresse;
            this.age = age;
            this.role = role;
        }
    }
}