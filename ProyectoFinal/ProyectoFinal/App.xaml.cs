using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ProyectoFinal
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			/** Pagina principal de la aplicacion
			 *  Muestra un menu tipo Drawer, que muestra las recetas por categoria,
			 *  ingrediente o la receta del dia
			*/			
			var mainPage = new DrawerMenuPage()
            {
                Title = "Recipes"
            };

            MainPage = new NavigationPage(mainPage);
			 
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
