using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    public partial class Foto : BaseDTO
    {
        public string Large { get; set; }

        public string Medium { get; set; }

        public string Thumbnail { get; set; }
    }
}
