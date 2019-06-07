using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week4.MenuItems;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using week4.Database; 

namespace week4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
	{
        DatabaseManager db = new DatabaseManager(); 
        List<MasterPageItem> masterPageItems = new List<MasterPageItem>(); 
        public MasterPage()
        {
            InitializeComponent();
            
            username.Text = Configuration.Username; 

            masterPageItems.Add(new MasterPageItem { Title = "Movies & Series", Icon = "", TargetType = typeof(MainPage)});
            masterPageItems.Add(new MasterPageItem { Title = "Favorites", Icon = "", TargetType = typeof(FavoritePage)});
            masterPageItems.Add(new MasterPageItem { Title = "Add", Icon = "", TargetType = typeof(AddPage)});

            NavigationDrawerList.ItemsSource = masterPageItems; 

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
        }

        private void NavigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType; 
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false; 
        }
    }
}