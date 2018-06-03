using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.Modelo;
using ProyectoFinal.ConsumeRestService;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace ProyectoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipesList : ContentPage
	{
		public RecipesList (List<Recipe> recipes, String title)
		{
			InitializeComponent ();
			Title = title;
			BindingContext = this;
			recipesList.ItemsSource = recipes;
			recipesList.ItemSelected += delegate {
				var seleccionado = recipesList.SelectedItem as Recipe;
				goToRecipe(seleccionado);
			};
		}

		private async void goToRecipe(Recipe recipe)
		{
			IsBusy = true;
			try
			{
				var json = await RestService.GetRecipeByIdJsonAsync(recipe.idMeal.ToString());

				Meals meals = JsonConvert.DeserializeObject<Meals>(json);

				if (meals.meals != null)
				{
					foreach (Recipe theRecipe in meals.meals)
					{
						recipe = theRecipe;
					}
				}else
				{
					await App.Current.MainPage.DisplayAlert("Error", "No Results were found", "OK");
				}
			}
			finally
			{
				IsBusy = false;
			}

			await Navigation.PushAsync(new RecipePage(recipe));
		}
	}
}