using Examen.App.Constantes;
using Examen.App.Servicios.Navegacion;
using Examen.App.Servicios.Settings;
using Examen.App.Views.Login;
using Examen.App.Views.Persona;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.App.ViewModels
{
    public class LocacionesViewModel
    {
        static LocacionesViewModel()
        {
            //REGISTRO DE VISTAS
            var navegacionServicio = new AdministradorNavegacion();
            navegacionServicio.Configure(ConstantesViewsApp.LoginView, typeof(LoginView));
            navegacionServicio.Configure(ConstantesViewsApp.PersonaView, typeof(PersonaView));

            //*****REGISTRAR SERVICIOS, INYECCION DE DEPENDENCIAS**********
            SimpleIoc.Default.Register<AdministradorNavegacion>(() => navegacionServicio);
            SimpleIoc.Default.Register<IAdministradorSettings, AdministradorSettings>();

            //*****REGISTRAR VIEWMODELS**********
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<PersonaViewModel>();
        }
    }
}
