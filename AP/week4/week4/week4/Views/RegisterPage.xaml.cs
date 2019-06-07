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
	public partial class RegisterPage : ContentPage
	{
        DatabaseManager db = new DatabaseManager();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            if (Password.Text == RepeatPassword.Text)
            {
                if (db.AddUser(Username.Text, Password.Text))
                {
                    Navigation.PushModalAsync(new MasterPage());
                }
                else
                    msg.Text = "Gebruikersnaam bestaat al!";
            }
            else
                msg.Text = "Wachtwoord is verkeerd ingevoerd";

        }
    }
}