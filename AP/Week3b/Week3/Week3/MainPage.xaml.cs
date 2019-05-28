using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week3
{
    public partial class MainPage : ContentPage
    {
        private string temperature { get; }

        public MainPage()
        {
            var c = new Client("172.16.0.217", 11000);
            temperature = c.GetTemp();
            InitializeComponent();
            BindingContext = this;
            l1.Text = temperature;
        }
    }
}
