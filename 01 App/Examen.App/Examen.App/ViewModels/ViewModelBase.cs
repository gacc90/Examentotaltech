using Examen.App.Comun;
using Examen.App.Servicios.Navegacion;
using Examen.App.Servicios.Settings;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.App.ViewModels
{
    public abstract class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase, INavigable
    {
        protected AdministradorNavegacion NavegacionServicio { get; }

        protected IAdministradorSettings SettingsServicio { get; }

        public bool IsActive { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetBusy(value) && !isBusy)
                {
                    BusyMessage = null;
                }
            }
        }

        private string busyMessage;
        public string BusyMessage
        {
            get => busyMessage;
            set => Set(ref busyMessage, value, broadcast: true);
        }

        public object parametro { get; set; }

        public ViewModelBase()
        {
            NavegacionServicio = SimpleIoc.Default.GetInstance<AdministradorNavegacion>();
            SettingsServicio = SimpleIoc.Default.GetInstance<IAdministradorSettings>();
        }

        protected virtual void OnIsBusyChanged()
        {
        }

        public virtual void Activate(object parameter)
        {
            this.parametro = parameter;
        }

        public virtual void Deactivate()
        {
        }

        public bool SetBusy(bool value, string message = null)
        {
            BusyMessage = message;

            var isSet = Set(() => IsBusy, ref isBusy, value, broadcast: true);
            if (isSet)
            {
                OnIsBusyChanged();
            }

            return isSet;
        }

    }
}
