using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.Modelo;
using ProyectoFinal.ConsumeRestService;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ProyectoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipesByCategory : ContentPage
	{
		private Category category { get; set; }
		public ObservableCollection<Recipe> list { get; set; }

		public RecipesByCategory (Category selectedCategory)
		{
			InitializeComponent ();
			category = selectedCategory;
			Title =  category.strCategory + " Recipes";
			BindingContext = this;
			list = new ObservableCollection<Recipe>();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			IsBusy = true;

			try
			{
				var json = await RestService.GetRecipesByCategoriesJsonAsync(category.strCategory);

				Meals meals = JsonConvert.DeserializeObject<Meals>(json);

				if (meals.meals != null)
				{
					foreach (var recipe in meals.meals)
					{
						list.Add(recipe);
					}
				}
				else
				{
					await App.Current.MainPage.DisplayAlert("Error", "No results were found.", "OK");
				}
			}
			finally
			{
				IsBusy = false;
			}

			recipesByCategoryList.ItemsSource = list;
			recipesByCategoryList.ItemSelected += delegate {
				var seleccionado = recipesByCategoryList.SelectedItem as Recipe;
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
					await App.Current.MainPage.DisplayAlert("Error", "There was an error with the connection.", "OK");
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