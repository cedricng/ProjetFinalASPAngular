//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetFinal.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commandes
    {
        public int id { get; set; }
        public int idClient { get; set; }
        public System.DateTime date { get; set; }
        public double prixtotal { get; set; }
        public string infos { get; set; }
    }
}
