using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.App.Comun
{
    public interface INavigable
    {
        void Activate(object parameter);

        void Deactivate();
    }
}
