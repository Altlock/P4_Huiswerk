using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week2
{
    public partial class MainPage : ContentPage
    {
        private DataBaseManager db;

        public MainPage()
        {
            var movies = new ObservableCollection<Movie>
            {
                new Movie
                {
                    Title = "The Avengers (2012)",
                    Description =
                        "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity."
                }
            };

            InitializeComponent();
            db = new DataBaseManager();
            db.AddOrUpdateMovie("The Avengers (2012)","Earth's mightiest heroes must come together and learn to fight as a team","");
            MovieList.ItemsSource = db.GetAllMovies();
        }

        private void RemoveButton_OnPressed(object sender, EventArgs e)
        {
            db.DeleteMovie("");
        }

        private void AddUpdateButton_OnPressed(object sender, EventArgs e)
        {
            db.AddOrUpdateMovie("Test","Test test","");
        }
    }
}
