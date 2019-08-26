using Examen.App.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen.App.Views.Persona
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaPersonasView : ContenPageBase
    {
		public ListaPersonasView()
		{
			InitializeComponent ();
		}
	}
}