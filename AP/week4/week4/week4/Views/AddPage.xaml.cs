using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week4.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace week4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
        private bool isSeries = false;
        private bool defualtEntry = false;
        private bool seriesEntry = false; 

        DatabaseManager db = new DatabaseManager(); 
        public AddPage()
        {
            InitializeComponent();
        }
        private void SelectImage_Clicked(object sender, EventArgs e)
        {
            var imageSender = (Image)sender;
            if (imageSender.ClassId != "2")
                isSeries = true;
            else
                isSeries = false; 

            if (isSeries)
            {
                MovieButton.Opacity = 1.0;
                SeriesButton.Opacity = 0.5; 
                YearEndedEntry.IsVisible = true; 
                NumberOfEpisodesEntry.IsVisible = true; 
                NumberOfSeasonsEntry.IsVisible = true; 
            }
        }

        private void checkEntry()
        {
            if (TitleEntry.Text != null && DescriptionEntry.Text != null && YearEntry.Text != null)
                defualtEntry = true;

            if (NumberOfEpisodesEntry.Text != null && NumberOfSeasonsEntry.Text != null)
                seriesEntry = true; 
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            if (!isSeries)
            {
                if (defualtEntry)
                    db.AddOrUpdateMovie(TitleEntry.Text, DescriptionEntry.Text, YearEntry.Text);
            }
            else
            {
                if (defualtEntry && seriesEntry)
                {
                    int yearEnded;
                    if (YearEndedEntry.Text == null)
                        yearEnded = -1;
                    else
                        yearEnded = Convert.ToInt32(YearEndedEntry.Text); 

                    db.AddSeries(TitleEntry.Text, DescriptionEntry.Text, Convert.ToInt32(YearEntry.Text), yearEnded, Convert.ToInt32(NumberOfEpisodesEntry.Text), Convert.ToInt32(NumberOfSeasonsEntry.Text));
                }
            }
        }
    }
}