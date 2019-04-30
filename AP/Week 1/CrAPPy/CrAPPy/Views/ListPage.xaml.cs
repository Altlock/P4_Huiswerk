using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrAPPy.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
    {
		public ListPage (IEnumerable<string> l)
        {
            InitializeComponent ();
            Content = new ListView {ItemsSource = l};
        }
	}
}