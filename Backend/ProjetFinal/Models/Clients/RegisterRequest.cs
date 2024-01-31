using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetFinal.Models.Clients
{
    public class RegisterRequest

    {
        [Required]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string password { get; set; }
        public string telephone { get; set; }
        public string adresse { get; set; }
        public Nullable<int> age { get; set; }
        public string role { get; set; }

 
    }
}