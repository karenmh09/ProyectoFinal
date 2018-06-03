using Plugin.Connectivity;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoFinal.ConsumeRestService
{
	sealed class RestService
	{
		private static RestService _instance = null;
		public const string SERVICE_ENDPOINT = "https://www.themealdb.com/api/json/v1/1/";
		private static string randomRecipe = "";
		private static string categories = "";
		private static string recipesByCategory = "";
		private static string selectedCategory = "";
		private static string selectedRecipeId = "";
		private static string recipe = "";
		private static string recipeByMainIngredient = "";
		private static string selectedMainIngredient = "";
		private static string selectedNameRecipe = "";
		private static string recipeByNameRecipe = "";

		private RestService()
		{
		}

		static internal RestService getInstance()
		{
			if (_instance == null)
			{
				_instance = new RestService();
			}
			return _instance;
		}

		static internal async Task<string> GetRandomRecipeJsonAsync()
		{
			if (randomRecipe.Length > 0)
			{
				Debug.WriteLine("Ya existe");
				return randomRecipe;
			}
			if (!CrossConnectivity.Current.IsConnected)
			{
				Debug.WriteLine("No network");
				return string.Empty;
			}
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(SERVICE_ENDPOINT);
				randomRecipe = await client.GetStringAsync($"random.php");
				Debug.WriteLine(randomRecipe);
				return randomRecipe;
			}
		}

		static internal async Task<string> GetCategoriesJsonAsync()
		{
			if(categories.Length > 0)
			{
				Debug.WriteLine("Ya existe");
				return categories;
			}
			if (!CrossConnectivity.Current.IsConnected)
			{
				Debug.WriteLine("No network");
				return string.Empty;
			}
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(SERVICE_ENDPOINT);

				categories = await client.GetStringAsync($"categories.php");

				Debug.WriteLine(categories);

				return categories;
			}
		}

		//https://www.themealdb.com/api/json/v1/1/filter.php?c=Seafood
		static internal async Task<string> GetRecipesByCategoriesJsonAsync(String category)
		{
			if(recipesByCategory.Length > 0 && selectedCategory.Equals(category))
			{
				Debug.WriteLine("Ya existe");
				return recipesByCategory;
			}
			if (!CrossConnectivity.Current.IsConnected)
			{
				Debug.WriteLine("No network");
				return string.Empty;
			}
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(SERVICE_ENDPOINT);

				var json = await client.GetStringAsync($"filter.php?c=" + category);
				selectedCategory = category;
				Debug.WriteLine(json);

				return json;
			}
		}

		static internal async Task<string> GetRecipeByIdJsonAsync(String recipeId)
		{
			if (recipe.Length > 0 && selectedRecipeId.Equals(recipeId))
			{
				Debug.WriteLine("Ya existe");
				return recipesByCategory;
			}
			if (!CrossConnectivity.Current.IsConnected)
			{
				Debug.WriteLine("No network");
				return string.Empty;
			}
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(SERVICE_ENDPOINT);

				recipe = await client.GetStringAsync($"lookup.php?i=" + recipeId );
				selectedRecipeId = recipeId;
				Debug.WriteLine(recipe);

				return recipe;
			}
		}

		//https://www.themealdb.com/api/json/v1/1/filter.php?i=chicken%20breast
		static internal async Task<string> GetRecipesByMainIngredientJsonAsync(String mainIngredient)
		{
			if (recipeByMainIngredient.Length > 0 && selectedMainIngredient.Equals(mainIngredient))
			{
				Debug.WriteLine("Ya existe");
				return recipeByMainIngredient;
			}
			if (!CrossConnectivity.Current.IsConnected)
			{
				Debug.WriteLine("No network");
				return string.Empty;
			}
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(SERVICE_ENDPOINT);

				recipeByMainIngredient = await client.GetStringAsync($"filter.php?i=" + mainIngredient);
				selectedMainIngredient = mainIngredient;
				Debug.WriteLine(recipeByMainIngredient);

				return recipeByMainIngredient;
			}
		}

		//https://www.themealdb.com/api/json/v1/1/search.php?s=Arrabiata
		static internal async Task<string> GetRecipesByNameJsonAsync(String recipeName)
		{
			if (recipeByNameRecipe.Length > 0 && selectedNameRecipe.Equals(recipeName))
			{
				Debug.WriteLine("Ya existe");
				return recipeByNameRecipe;
			}
			if (!CrossConnectivity.Current.IsConnected)
			{
				Debug.WriteLine("No network");
				return string.Empty;
			}
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(SERVICE_ENDPOINT);

				recipeByNameRecipe = await client.GetStringAsync($"search.php?s=" + recipeName);
				selectedNameRecipe = recipeName;
				Debug.WriteLine(recipeByNameRecipe);

				return recipeByNameRecipe;
			}
		}
	}
}
