using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tickets());
        }

        private void Button_Clicked3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUI());
        }

        private void Button_ClickedShow(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowInfo());
        }

        private void Button_ClickedMg(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageInfo());
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeliveryInform());
        }
        private void Button_Feedback(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Feedback());
        }
    }
}
