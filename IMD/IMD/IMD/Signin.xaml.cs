using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMD.Models;
using IMD.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace IMD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signin : ContentPage
    {
        IAuth auth;

        public Signin()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void Button_ClickedSignin(object sender, EventArgs e)
        {
            User user = new User()
            {
                BienSo = txtBsx.Text,
                DongXe = txtDongxe.Text,
                HoTen = txtHovaten.Text,
                MaSV = txtMsv.Text,
                MauXe = txtMauxe.Text,
                NhapLaiMatKhau = txtNhapLai.Text,
                NhapMatKhau = txtNhapPassword.Text
            };

            var Bsx = await auth.SigninWithUserAndPass(txtBsx.Text, txtNhapPassword.Text);
            user.Uid = Bsx;
            bool isOK = await UserInfoUtilities.CreateUserInfo(user, async (o) => 
            {
                await DisplayAlert("Thông báo", o, "OK");
            });
            if (isOK)
            {
                await DisplayAlert("Thành công", "Đã tạo tài khoản mới", "Ok");
            }
            Application.Current.MainPage.Navigation.PopAsync();

        }
    }
}

