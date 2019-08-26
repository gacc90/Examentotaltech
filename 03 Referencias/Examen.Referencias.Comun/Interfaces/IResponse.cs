using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Referencias.Comun.Interfaces
{
    public interface IResponse
    {
        string Mensaje { get; set; }

        bool ExisteError { get; set; }

        string ErrorMensaje { get; set; }
    }
}
