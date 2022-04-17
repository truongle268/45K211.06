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
    public partial class Signin : ContentPage
    {
        public Signin()
        {
            InitializeComponent();
        }
        Models.ShowInfoModel _showinfo;
        public Signin(Models.ShowInfoModel showinfo)
        {
            InitializeComponent();

            Title = "Edit ShowInfo";
            _showinfo = showinfo;

            txtHovaten.Text = showinfo.HoTen;
            txtMsv.Text = showinfo.MaSV;
            txtBsx.Text = showinfo.BienSo;
            txtDongxe.Text = showinfo.DongXe;
            txtMauxe.Text = showinfo.MauXe;
            txtNhapPassword.Text = showinfo.MatKhau;

            txtHovaten.Focus();
            txtMsv.Focus();
            txtBsx.Focus();
            txtDongxe.Focus();
            txtMauxe.Focus();
            txtNhapPassword.Focus();
        }

        async void Button_ClickedSignin(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHovaten.Text) || 
                string.IsNullOrWhiteSpace(txtMsv.Text) ||
                string.IsNullOrWhiteSpace(txtBsx.Text) ||
                string.IsNullOrWhiteSpace(txtDongxe.Text) ||
                string.IsNullOrWhiteSpace(txtMauxe.Text) ||
                string.IsNullOrWhiteSpace(txtNhapPassword.Text))
            {
                await DisplayAlert("Thông báo!", "Bạn chưa nhập đầy đủ thông tin!", "OK");
            }
            else if (_showinfo != null)
            {
                EditShowInfo();
            }
            else
                AddNewShowInfo();
        }

        async void AddNewShowInfo()
        {
            await App.MyDatabaseSI.CreateShowInfo(new Models.ShowInfoModel
            {
                HoTen = txtHovaten.Text,
                MaSV = txtMsv.Text,
                BienSo = txtBsx.Text,
                DongXe = txtDongxe.Text,
                MauXe = txtMauxe.Text,
                MatKhau = txtNhapPassword.Text

        });
            await Navigation.PopAsync();
        }
        async void EditShowInfo()
        {
            _showinfo.HoTen = txtHovaten.Text;
            _showinfo.MaSV = txtMsv.Text;
            _showinfo.BienSo = txtBsx.Text;
            _showinfo.DongXe = txtDongxe.Text;
            _showinfo.MauXe = txtMauxe.Text;
            _showinfo.MatKhau = txtNhapPassword.Text;

            await App.MyDatabaseSI.UpdateShowInfo(_showinfo);
            await Navigation.PopAsync();
        }
    }
}

