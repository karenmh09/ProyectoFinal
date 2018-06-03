using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.ConsumeRestService;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using ProyectoFinal.Modelo;
using Newtonsoft.Json;

namespace ProyectoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchRecipePage
	{
		public SearchRecipePage ()
		{
			InitializeComponent ();
			BindingContext = this;
			btnSearchByIngredient.Command = new Command(obj => SearchByIngredient());
			btnSearchByName.Command = new Command(obj => SearchByName());
		}

		public void SearchByIngredient()
		{
			if (txtSearchByIngredient.Text == null || txtSearchByIngredient.Text.Length == 0)
			{
				App.Current.MainPage.DisplayAlert("Error", "Please enter a valid entry.", "OK");
			} else
			{
				if (Regex.IsMatch(txtSearchByIngredient.Text, @"^[a-zA-Z ]+$"))
				{
					string ingredient = txtSearchByIngredient.Text.Replace(" ", "%20");
					doSearchByIngredient(ingredient);
				}else
				{
					App.Current.MainPage.DisplayAlert("Error", "Please ingredients can only contain letters.", "OK");
				}
			}

		}

		public void SearchByName()
		{
			if (txtSearchByName.Text == null || txtSearchByName.Text.Length == 0)
			{
				App.Current.MainPage.DisplayAlert("Error", "Please enter a valid entry.", "OK");
			}else
			{
				if (Regex.IsMatch(txtSearchByName.Text, @"^[a-zA-Z ]+$"))
				{
					string name = txtSearchByName.Text.Replace(" ", "%20");
					doSearchByName(name);
				}
				else
				{
					App.Current.MainPage.DisplayAlert("Error", "Please ingredients can only contain letters.", "OK");
				}
			}
		}

		private async void doSearchByIngredient(String ingredient)
		{
			Meals meals;
			IsBusy = true;

			try
			{
				var json = await RestService.GetRecipesByMainIngredientJsonAsync(ingredient);

				meals = JsonConvert.DeserializeObject<Meals>(json);
			}
			finally
			{
				IsBusy = false;
			}

			if (meals.meals != null)
			{
				goToRecipesListPage(meals.meals, ingredient);
			}else
			{
				await App.Current.MainPage.DisplayAlert("Error", "No Results were found", "OK");
			}
		}

		private async void doSearchByName (string name)
		{
			Meals meals;
			Recipe recipe = null;
			IsBusy = true;

			try
			{
				var json = await RestService.GetRecipesByNameJsonAsync(name);

				meals = JsonConvert.DeserializeObject<Meals>(json);
			}
			finally
			{
				IsBusy = false;
			}

			if (meals.meals != null)
			{
				foreach (var theRecipe in meals.meals)
				{
					recipe = theRecipe;
				}

				goToRecipePage(recipe);
			}
			else
			{
				await App.Current.MainPage.DisplayAlert("Error", "No Results were found", "OK");
			}
		}
		private async void goToRecipesListPage(List<Recipe> recipes, String ingredient)
		{
			await Navigation.PushAsync(new RecipesList(recipes, "Results for \"" + ingredient + "\""));
		}

		private async void goToRecipePage(Recipe recipe)
		{
			await Navigation.PushAsync(new RecipePage(recipe));
		}
	}
}