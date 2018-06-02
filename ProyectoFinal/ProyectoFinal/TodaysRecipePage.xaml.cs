using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProyectoFinal.ConsumeRestService;
using ProyectoFinal.Modelo;

namespace ProyectoFinal
{
	//https://www.themealdb.com/api/json/v1/1/random.php

	public partial class TodaysRecipePage : ContentPage
	{
		private Recipe TodayRecipe { get; set; }

		public TodaysRecipePage()
		{
			InitializeComponent();
			BindingContext = this;
			Title = "Today's Recipe";
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			IsBusy = true;

			try
			{
				var json = await RestService.GetRandomRecipeJsonAsync();
				var meals = JsonConvert.DeserializeObject<Meals>(json);

				foreach (var recipe in meals.meals)
				{
					TodayRecipe = recipe;
					RecipeTitle.Text = recipe.strMeal;
					RecipeCategory.Text = recipe.strCategory;
					RecipeIngredients.Text = recipe.getIngredientes();
					RecipeInstructions.Text = recipe.strInstructions;

					/*RecipeImage.Source = new UriImageSource
					{
						Uri = new Uri(recipe.strMealThumb),
						CachingEnabled = true,
						CacheValidity = new TimeSpan(5, 0, 0, 0)
					};*/

					//webImage.Source = "https://xamarin.com/content/images/pages/forms/example-app.png";
					//image.Source = new UriImageSource { CachingEnabled = false, Uri="http://server.com/image" };
					/**webImage.Source = new UriImageSource
					{
						Uri = new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"),
						CachingEnabled = true,
						CacheValidity = new TimeSpan(5,0,0,0)
					};*/
				}


			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
