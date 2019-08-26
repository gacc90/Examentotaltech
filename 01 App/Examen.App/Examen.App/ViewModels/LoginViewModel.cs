using Examen.App.Comun;
using Examen.Servicios.Aplicacion.Helpers;
using Examen.Servicios.Entidades.Validadores;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Modelo = Examen.Servicios.Entidades.Modelo;

namespace Examen.App.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        public AutoRelayCommand IngresarCommand { get; private set; }

        #region Propiedades View

        private string correo;
        private string password;
        private string error;

        public string Correo
        {
            get => correo;
            set
            {               
                Set(ref correo, value);
            }
        }

        public string Password
        {
            get => password;
            set
            {               
                Set(ref password, value);
            }
        }

        public string Error
        {
            get => error;
            set => Set(ref error, value);
        }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            IngresarCommand = new AutoRelayCommand(async () => await Ingresar());           
        }

        #endregion

        #region Metodos

        private async Task Ingresar()
        {
            this.IsBusy = true;
            ValidatorLogin validador = new ValidatorLogin();
            ValidationResult resultadoValidador = (await validador.ValidateAsync(new Modelo.Usuario() { Correo = Correo, Password = Password }));
            if (resultadoValidador.IsValid)
            {
                var usuario = await ApiLoginJson.Instance.Login(Correo, Password);
                if (!usuario.ExisteError)
                {
                    if (usuario.Model != null)
                    {
                        this.SettingsServicio.IngresarUsuario(usuario.Model);
                        Xamarin.Forms.Application.Current.MainPage = new Xamarin.Forms.NavigationPage(new Views.Persona.ListaPersonasView());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Advertencia", usuario.Mensaje, "Aceptar");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", usuario.ErrorMensaje, "Aceptar");
                }
            }
            else
            {
                foreach (var error in resultadoValidador.Errors)
                {
                    //if ("Password" == error.PropertyName)
                    //{
                    //    MostrarErrorPassword = true;
                    //}
                    //else if ("Correo" == error.PropertyName)
                    //{
                    //    MostrarErrorUsuario = true;
                    //}
                }
            }
            this.IsBusy = false;
        }

        public void LipiarVista()
        {
            Correo = null;
            Password = null;
        }

        #endregion
    }
}
