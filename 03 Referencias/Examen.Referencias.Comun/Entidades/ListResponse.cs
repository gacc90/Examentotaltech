using Examen.Referencias.Comun.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Referencias.Comun.Entidades
{
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string Mensaje { get; set; }

        public bool ExisteError { get; set; }

        public string ErrorMensaje { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
