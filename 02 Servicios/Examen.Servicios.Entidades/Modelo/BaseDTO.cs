using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Modelo
{
    public abstract class BaseDTO : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            if (!_isDisposed)
            {
                this._isDisposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }  
}
