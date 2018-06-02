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
		private RestService RestServiceClient { get; set; }
		private Recipe TodayRecipe { get; set; }

		public TodaysRecipePage()
		{
			InitializeComponent();
			Title = "Today's Recipe";
			RestServiceClient = new RestService();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			IsBusy = true;

			try
			{
				var json = await RestServiceClient.GetRandomRecipeJsonAsync();
				var meals = JsonConvert.DeserializeObject<Meals>(json);

				foreach (var recipe in meals.meals)
				{
					TodayRecipe = recipe;
					RecipeTitle.Text = recipe.strCategory;
					RecipeIngredients.Text = recipe.getIngredientes();
					RecipeInstructions.Text = recipe.strInstructions;

					RecipeImage.Source = new UriImageSource
					{
						Uri = new Uri(recipe.strMealThumb),
						CachingEnabled = true,
						CacheValidity = new TimeSpan(5, 0, 0, 0)
					};
				}

				
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
