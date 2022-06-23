using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGEVALP.Models
{
    public static class Rol
    {
        public const string AdminGeneral = "AdminGeneral";
        public const string AdminWeb = "AdminWeb";
        public const string Almacenero = "Almacenero";
        public const string JefeAlmacen = "JefeAlmacen";   
        //@Urp2021
    }

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}