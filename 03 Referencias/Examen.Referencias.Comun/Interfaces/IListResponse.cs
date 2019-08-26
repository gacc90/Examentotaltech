using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Referencias.Comun.Interfaces
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }   
}
