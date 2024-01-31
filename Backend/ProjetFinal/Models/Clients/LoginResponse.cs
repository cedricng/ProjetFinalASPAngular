using System;

namespace ProjetFinal.Models.Clients
{

    public class LoginResponse
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public string username { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string telephone { get; set; }
        public string adresse { get; set; }
        public Nullable<int> age { get; set; }
        public string role { get; set; }
        public string token { get; set; }
    }
}