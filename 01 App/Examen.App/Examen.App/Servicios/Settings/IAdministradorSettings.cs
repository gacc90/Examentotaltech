using System;
using System.Collections.Generic;
using System.Text;
using Modelo = Examen.Servicios.Entidades.Modelo;

namespace Examen.App.Servicios.Settings
{
    public interface IAdministradorSettings
    {
        string UsuarioLogueado { get; set; }

        void Limpiar();

        void IngresarUsuario(Modelo.Usuario usuario);
    }
}
