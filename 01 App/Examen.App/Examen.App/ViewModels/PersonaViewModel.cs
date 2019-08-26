using Examen.App.Comun;
using Examen.App.Constantes;
using Examen.Referencias.Comun.Interfaces;
using Examen.Servicios.Aplicacion.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Modelo = Examen.Servicios.Entidades.Modelo;

namespace Examen.App.ViewModels
{
    public class PersonaViewModel : ViewModelBase
    {
        #region Comandos
       
        public AutoRelayCommand<object> SeleccionarPersonaCommand { get; private set; }
       
        public AutoRelayCommand ActualizarListaCommand { get; private set; }

        #endregion

        #region Propiedades

        private Modelo.Persona persona;

        private ObservableCollection<Modelo.Persona> listaPersonas;

        private bool actualizandoLista;

        public Modelo.Persona Persona
        {
            get => persona;
            set => Set(ref persona, value);
        }

        public ObservableCollection<Modelo.Persona> ListaPersonas
        {
            get => listaPersonas;
            set => Set(ref listaPersonas, value);
        }

        public bool ActualizandoLista
        {
            get => actualizandoLista;
            set => Set(ref actualizandoLista, value);
        }

        #endregion

        #region Constructor

        public PersonaViewModel()
        {
            this.IsBusy = true;
            SeleccionarPersonaCommand = new AutoRelayCommand<object>(async (obj) => await SeleccionarPersona(obj));
            ActualizarListaCommand = new AutoRelayCommand(async () => await ActualizarLista());
            Task.Run(async () => await ConsultarPersonas()).Wait();
            this.IsBusy = false;
        }
       
        #endregion


        private async Task ConsultarPersonas()
        {
            try
            {
                var personas = (await ApiPersonaJson.Instance.ObtenerPersonas<IListResponse<Modelo.Persona>>($"10"));
                if (ListaPersonas != null)
                    ListaPersonas.Clear();
                ListaPersonas = new ObservableCollection<Modelo.Persona>(personas as List<Modelo.Persona>);                    
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private async Task SeleccionarPersona(object usuario)
        {         
            iniciarPersona();
            NavegacionServicio.NavigateTo(ConstantesViewsApp.PersonaView);
        }

        private async Task iniciarPersona()
        {
            if (Persona != null)
            {                
            }
        }

        private async Task ActualizarLista()
        {
            ActualizandoLista = true;
            await Task.Delay(2000);
            ActualizandoLista = false;
        }
    }
}
