using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.Modelo;
using ProyectoFinal.ConsumeRestService;
using Newtonsoft.Json;

namespace ProyectoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryListPage : ContentPage
	{
		public ObservableCollection<Category> list { get; set; }

		public CategoryListPage ()
		{
			InitializeComponent ();
			Title = "Recipe's Categories";
			BindingContext = this;
			list = new ObservableCollection<Category>();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			IsBusy = true;

			try
			{
				var json = await RestService.GetCategoriesJsonAsync();

				Categories Categories = JsonConvert.DeserializeObject<Categories>(json);
				
				if (Categories.categories != null)
				{
					foreach (var category in Categories.categories)
					{
						list.Add(category);
					}
				}
			}
			finally
			{
				IsBusy = false;
			}

			categoriesList.ItemsSource = list;
			categoriesList.ItemSelected += delegate {
				var seleccionado = categoriesList.SelectedItem as Category;
				goToRecipesByCategory(seleccionado);
			};
		}

		private async void goToRecipesByCategory(Category category)
		{
			await Navigation.PushAsync(new RecipesByCategory(category));
		}
	}
}