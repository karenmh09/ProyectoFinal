using System;
using Xamarin.Forms;

namespace ProyectoFinal
{
	public partial class DrawerMenuPage : MasterDetailPage
	{
		public DrawerMenuPage()
		{
			InitializeComponent();

			masterPage.ListView.ItemSelected += OnItemSelected;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}
