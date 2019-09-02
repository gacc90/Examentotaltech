using Examen.Referencias.Comun.Entidades;
using Examen.Referencias.Comun.Interfaces;
using Examen.Servicios.Comun.Constantes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Modelo = Examen.Servicios.Entidades.Modelo;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Examen.Servicios.Aplicacion.Helpers
{
    public class ApiPersonaJson : HttpClient
    {
        private static readonly ApiPersonaJson instance = new ApiPersonaJson();
        static ApiPersonaJson() { }

        private ApiPersonaJson() : base()
        {
            Timeout = TimeSpan.FromMilliseconds(15000);
            MaxResponseContentBufferSize = 256000;
            BaseAddress = new Uri(ConstanteApp.WebApiPersonaUrl);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static ApiPersonaJson Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<IListResponse<Modelo.Persona>> ObtenerPersonas<T>(string numeroPagina)
        {
            try
            {
                var response = await GetAsync($"?results{numeroPagina}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject jo = JObject.Parse(content);
                    JToken token = (jo["results"] as JArray);
                    var lista = JsonConvert.DeserializeObject<IEnumerable<Modelo.Persona>>(token.ToString());
                    var listaResponse = new ListResponse<Modelo.Persona>();
                    listaResponse.Model = lista.ToList();
                    return listaResponse;
                }
                else
                {
                    return default(IListResponse<Modelo.Persona>);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
