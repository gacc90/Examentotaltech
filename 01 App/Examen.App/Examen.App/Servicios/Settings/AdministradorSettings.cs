using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo = Examen.Servicios.Entidades.Modelo;

namespace Examen.App.Servicios.Settings
{
    public class AdministradorSettings : IAdministradorSettings
    {
        private const string TOKEN = nameof(TOKEN);
        private const string CORREO = nameof(CORREO);
        private const string USUARIO_LOGUEADO = nameof(USUARIO_LOGUEADO);

        private readonly ISettings settings;

        public AdministradorSettings()
        {
            settings = CrossSettings.Current;
        }

        public string Token
        {
            get => settings.GetValueOrDefault(TOKEN, null);
            set => settings.AddOrUpdateValue(TOKEN, value);
        }

        public string Correo
        {
            get => settings.GetValueOrDefault(CORREO, null);
            set => settings.AddOrUpdateValue(CORREO, value);
        }

        public string UsuarioLogueado
        {
            get => settings.GetValueOrDefault(USUARIO_LOGUEADO, null);
            set => settings.AddOrUpdateValue(USUARIO_LOGUEADO, value);
        }

        public void IngresarUsuario(Modelo.Usuario usuario)
        {
            Token = usuario.Token;
            Correo = usuario.Correo;          
            UsuarioLogueado = "1";           
        }

        public void Limpiar()
        {
            Correo = null;
            Token = null;           
            UsuarioLogueado = null;
        }
    }
}
