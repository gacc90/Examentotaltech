using Examen.App.Servicios.Settings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Examen.App
{
    public partial class App : Application
    {
        public static bool EnPausa { get; set; }

        public readonly IAdministradorSettings settings;

        public App()
        {
            InitializeComponent();

            settings = new AdministradorSettings();
            if (settings.UsuarioLogueado == "1")
            {
                MainPage = new NavigationPage(new Views.Persona.ListaPersonasView());
            }
            else
            {
                MainPage = new NavigationPage(new Views.Login.LoginView());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
