using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrAPPy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private List<string> nameList;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ShowButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ListPage(nameList));
        }

        private void AddButton_OnClicked(object sender, EventArgs e)
        {
            if (NameEntry.Text.Length != 0)
            {
                nameList.Add(NameEntry.Text);
                return;
            }
            DisplayAlert(
                "Lege invulbox",
                "Als je iets wilt toevoegen aan de lijst, moet je iets in de invulbox typen.",
                "Ok");
        }
    }
}