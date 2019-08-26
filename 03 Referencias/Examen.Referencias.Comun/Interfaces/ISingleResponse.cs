using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Referencias.Comun.Interfaces
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
