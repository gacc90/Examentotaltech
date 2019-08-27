using Examen.Referencias.Comun.Entidades;
using Examen.Referencias.Comun.Interfaces;
using Examen.Servicios.Comun.Constantes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Modelo = Examen.Servicios.Entidades.Modelo;

namespace Examen.Servicios.Aplicacion.Helpers
{
    public class ApiLoginJson : HttpClient
    {
        private static readonly ApiLoginJson instance = new ApiLoginJson();
        static ApiLoginJson() { }

        private ApiLoginJson() : base()
        {
            Timeout = TimeSpan.FromMilliseconds(15000);
            MaxResponseContentBufferSize = 256000;
            BaseAddress = new Uri(ConstanteApp.WebApiLoginUrl);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static ApiLoginJson Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<ISingleResponse<Modelo.Usuario>> Login(string usuario, string password)
        {
            var usuarioResponse = new SingleResponse<Modelo.Usuario>();
            try
            {
                var credenciales = new {email = usuario, password };
                var cuerpo = JsonConvert.SerializeObject(credenciales);
                var content = new StringContent(cuerpo, Encoding.UTF8, "application/json");
                var response = (await PostAsync("api/login", content));

                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Modelo.Usuario>(json);               
                if (response.IsSuccessStatusCode)
                {                    
                    usuarioResponse.Model = resultado;
                }
                else
                {
                    usuarioResponse.ExisteError = true;
                    usuarioResponse.ErrorMensaje = "La contraseña o el correo es incorrecto.";
                    usuarioResponse.Model = null;
                }
            }
            catch (Exception ex)
            {
                usuarioResponse.ExisteError = true;
                //usuarioResponse.SetError(nameof(Login), ex);
            }
            return usuarioResponse;
        }
    }
}
