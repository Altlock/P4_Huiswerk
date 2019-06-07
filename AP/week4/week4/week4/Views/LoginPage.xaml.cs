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
	public partial class LoginPage : ContentPage
	{
        DatabaseManager db = new DatabaseManager();
        public LoginPage()
        {
            InitializeComponent();
            KlikLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Register_Clicked()),
            });
        }
        private void Register_Clicked()
        {
            Navigation.PushModalAsync(new RegisterPage());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (db.doesAccountExist(Username.Text, Password.Text))
            {
                var User = db.GetUser(Username.Text, Password.Text);
                //newpage.BindingContext = User; 
                Configuration.Username = Username.Text;

                Application.Current.MainPage = new MasterPage();
            }
            else
                WrongCredmsg.Text = "Account bestaat niet of wachtwoord klopt niet";
        }
    }
}