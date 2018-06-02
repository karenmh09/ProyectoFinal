using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchRecipePage
	{
		public SearchRecipePage ()
		{
			InitializeComponent ();
			btnSearchByIngredient.Command = new Command(obj => SearchByIngredient());
			btnSearchByName.Command = new Command(obj => SearchByName());
		}

		public void SearchByIngredient()
		{
			if(txtSearchByIngredient.Text.Length < 0)
			{
				App.Current.MainPage.DisplayAlert("Error" ,"Please enter a valid entry.", "OK");
			}

		}

		public void SearchByName()
		{
			if (txtSearchByName.Text.Length < 0)
			{
				App.Current.MainPage.DisplayAlert("Error", "Please enter a valid entry.", "OK");
			}
		}
	}
}