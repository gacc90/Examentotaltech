using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    [Serializable]
    public partial class Persona : BaseDTO
    {
        public string NombreCompleto => $"{Nombres.Alias} {Nombres.Nombre} {Nombres.Apellido}";

        [JsonProperty("name")]
        public Nombres Nombres { get; set; }

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

    public class Nombres
    {
        [JsonProperty("title")]
        public string Alias { get; set; }

        [JsonProperty("first")]
        public string Nombre { get; set; }

        [JsonProperty("last")]
        public string Apellido { get; set; }
    }
}
