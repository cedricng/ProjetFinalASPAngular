using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinal.Helpers
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public string Database {  get; set; }
        public string ConnectionString { get; set; }
    }
}