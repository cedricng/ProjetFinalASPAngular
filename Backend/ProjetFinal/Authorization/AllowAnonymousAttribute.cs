using System;
using System.Web.Mvc;

namespace ProjetFinal.Authorization
{

    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }
}