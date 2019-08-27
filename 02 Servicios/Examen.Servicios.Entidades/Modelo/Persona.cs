using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    [Serializable]
    [JsonObject(Title = "results")]
    public partial class Persona : BaseDTO
    {
        [JsonProperty("name")]
        public string NombreCompleto { get; set; }

        public string Rating { get; set; }

        [JsonProperty("email")]
        public string Correo { get; set; }

        [JsonProperty("phone")]
        public string Telefono { get; set; }

        [JsonProperty("location")]
        public virtual Direccion Direccion { get; set; }

        [JsonProperty("picture")]
        public virtual Foto Foto { get; set; }
    }
}
