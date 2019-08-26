using Examen.App.Servicios.Navegacion;
using Examen.App.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Examen.App.Comun
{
    public abstract class ContenPageBase: ContentPage
    {
        public ContenPageBase()
        {
            On<iOS>().SetUseSafeArea(true);           
            Xamarin.Forms.NavigationPage.SetBackButtonTitle(this, String.Empty);
        }

        protected override void OnAppearing()
        {
            if (BindingContext is ViewModelBase viewModel && !viewModel.IsActive)
            {
                viewModel.Activate(this.GetNavigationArgs());
                viewModel.IsActive = true;               
            }
            else if (App.EnPausa)
            {
                App.EnPausa = false;
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            if (BindingContext is ViewModelBase viewModel && !App.EnPausa)
            {
                viewModel.Deactivate();
                viewModel.IsActive = false;
            }

            Messenger.Default.Unregister(this);
            base.OnDisappearing();
        }
    }
}
