using Examen.Referencias.Comun.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Referencias.Comun.Entidades
{
    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : new()
    {
        public SingleResponse()
        {
            Model = new TModel();
        }

        public string Mensaje { get; set; }

        public bool ExisteError { get; set; }

        public string ErrorMensaje { get; set; }

        public TModel Model { get; set; }
    }
}
