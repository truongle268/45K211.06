using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMD.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace IMD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowInfo : ContentPage
    {
        public ShowInfo()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myShowInfo.ItemsSource = await App.MyDatabaseSI.ReadShowInfo();
            }
            catch { }
        }

        async void Toolbar_ClickedUd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signin());
        }

        async void SwipeItem_InvokedSh(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as ShowInfoModel;
            await Navigation.PushAsync(new Signin(emp));
        }

        async void SwipeItem_InvokedDl(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as ShowInfoModel;
            var result = await DisplayAlert("Thông báo!", "Bạn có muốn xóa?", "Yes", "No");
            if (result)
            {
                await App.MyDatabaseSI.DeleteShowInfo(emp);
                myShowInfo.ItemsSource = await App.MyDatabaseSI.ReadShowInfo();
            }

        }
    }
    
}