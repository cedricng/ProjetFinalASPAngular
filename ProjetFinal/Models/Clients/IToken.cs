using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Models.Clients
{
    internal interface IToken
    {
        string accessToken { get; set; }
        string refreshToken { get; set; }
    
}
}
