using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    public partial class Direccion : BaseDTO
    {
        public string Calle { get; set; }

        public string Ciudad { get; set; }

        public string Estado { get; set; }

        public string CodigoPostal { get; set; }

        public virtual Coordenadas Coordenadas { get; set; }
    }
}
