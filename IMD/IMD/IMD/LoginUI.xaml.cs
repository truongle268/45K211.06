using IMD.Models;
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
    public partial class LoginUI : ContentPage
    {
        IAuth auth;
        public LoginUI()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            txtUsername.Text = "59b2-12345";
            txtPassword.Text = "123456";
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            string uid = await auth.LoginWithUserAndPass(txtUsername.Text, txtPassword.Text);
            if (uid != string.Empty)
            {
                Constants.Uid = uid;
                Constants.IsAdmin = Constants.Admins.Contains(txtUsername.Text);
                Application.Current.MainPage = new NavigationPage(new Home());
            }
            else
            {
               await DisplayAlert("Alert", "Tên đăng nhập hoặc mật khẩu không đúng!", "Ok");
            }    
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Signin());
        }
    }
}