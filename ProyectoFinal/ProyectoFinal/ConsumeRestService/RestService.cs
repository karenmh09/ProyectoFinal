using Plugin.Connectivity;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoFinal.ConsumeRestService
{
	class RestService
	{
		public const string SERVICE_ENDPOINT = "https://www.themealdb.com/api/json/v1/1/";
		private string randomRecipe = ""; 

		public async Task<string> GetRandomRecipeJsonAsync()
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

		public async Task<string> GetCategoriesJsonAsync()
		{
			if (!CrossConnectivity.Current.IsConnected)
			{
				Debug.WriteLine("No network");
				return string.Empty;
			}
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(SERVICE_ENDPOINT);

				var json = await client.GetStringAsync($"categories.php");

				Debug.WriteLine(json);

				return json;
			}
		}

		public async Task<bool> PostAsync(string json)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(SERVICE_ENDPOINT);

			var respuesta = await client.PostAsync("Employees",
				new StringContent(json, System.Text.Encoding.UTF8, "application/json"));

			return respuesta.StatusCode == HttpStatusCode.OK;
		}
	}
}
