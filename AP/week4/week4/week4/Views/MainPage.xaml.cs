using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week4.Database;
using week4.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace week4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        DatabaseManager db = new DatabaseManager();

        List<Movie> movies = new List<Movie>();
        List<Series> series = new List<Series>();

        public MainPage()
        {
            InitializeComponent();

            movies = db.GetAllMovies();
            series = db.GetAllSeries();

            MovieList.ItemsSource = movies;
            SerieList.ItemsSource = series;
        }
    }
}