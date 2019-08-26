using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    public partial class Usuario : BaseDTO
    {        
        public string Id { get; set; }

        public string Correo { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
