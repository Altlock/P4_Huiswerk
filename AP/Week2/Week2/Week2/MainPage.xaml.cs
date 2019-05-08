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
            MovieList.ItemsSource = movies;
        }

        private void RemoveButton_OnPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddUpdateButton_OnPressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
