using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMD.Models;
using IMD.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveryInform
    {
        public DeliveryInformViewModel ViewModel { get; set; }
        public DeliveryInform()
        {
            InitializeComponent();
            BindingContext = ViewModel = new DeliveryInformViewModel();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.MyDatabase.ReadInform();
            }
            catch { }
        }
        async void Toolbar_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.IsAdmin)
            {
                await Navigation.PushAsync(new InformDetail());
            }
            else
            {
                DisplayAlert("Thông báo", "User không được thêm thông báo!", "OK");
            }
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as InformModel;
            await Navigation.PushAsync(new InformDetail(emp));
        }
        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as InformModel;
            var result = await DisplayAlert("Delete", $"Delete {emp.Title} from the database", "Yes", "No");
            if (result)
            {
                await App.MyDatabase.DeleteInform(emp);
                myCollectionView.ItemsSource = await App.MyDatabase.ReadInform();
            }
        }
    }
}
