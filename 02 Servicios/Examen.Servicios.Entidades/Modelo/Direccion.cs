using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    public partial class Direccion : BaseDTO
    {
        [JsonProperty("street")]
        public string Calle { get; set; }

        [JsonProperty("city")]
        public string Ciudad { get; set; }

        [JsonProperty("state")]
        public string Estado { get; set; }

        [JsonProperty("postcode")]
        public string CodigoPostal { get; set; }

        [JsonProperty("coordinates")]
        public virtual Coordenadas Coordenadas { get; set; }
    }
}
