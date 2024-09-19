using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoAspPlatzi.Models.ViewsModel
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public string Correo { get; set; }
    }
}