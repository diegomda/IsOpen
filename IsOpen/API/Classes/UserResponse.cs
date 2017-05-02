using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Classes
{
    public class UserResponse
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Direccion { get; set; }

        public string Email { get; set; }
        public string Logo { get; set; }
        public List<Negocio> Negocio { get; set; }
    }
}