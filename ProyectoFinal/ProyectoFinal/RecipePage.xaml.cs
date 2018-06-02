using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.Modelo;
using ProyectoFinal.ConsumeRestService;
using Newtonsoft.Json;

namespace ProyectoFinal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipePage : ContentPage
	{
		public RecipePage(Recipe recipe)
		{
			InitializeComponent();
			Title = recipe.strMeal;

			RecipeTitle.Text = recipe.strMeal;
			RecipeCategory.Text = recipe.strCategory;
			RecipeIngredients.Text = recipe.getIngredientes();
			RecipeInstructions.Text = recipe.strInstructions;
		}

	}
}