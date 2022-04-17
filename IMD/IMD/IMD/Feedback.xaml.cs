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
    public partial class Feedback
    {
        public Feedback()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.MyDatabaseFB.ReadFeedback();
            }
            catch { }
        }
        async void Toolbar_ClickedFB(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeedbackDetail());
        }

        async void SwipeItem_InvokedFB(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as FeedbackModel;
            await Navigation.PushAsync(new FeedbackDetail(emp));
        }
        async void SwipeItem_InvokedFB1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as FeedbackModel;
            var result = await DisplayAlert("Delete", $"Delete {emp.TitleFB} from the database", "Yes", "No");
            if (result)
            {
                await App.MyDatabaseFB.DeleteFeedback(emp);
                myCollectionView.ItemsSource = await App.MyDatabaseFB.ReadFeedback();
            }
        }
        async void Searchbar_FB(object sender, TextChangedEventArgs e)
        {
            myCollectionView.ItemsSource = await App.MyDatabaseFB.Search(e.NewTextValue);
        }
    }
}