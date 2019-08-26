using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    public partial class Persona : BaseDTO
    {       
        public string NombreCompleto { get; set; }

        public string Rating { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public virtual Direccion Direccion { get; set; }

        public virtual Foto Foto { get; set; }
    }
}
