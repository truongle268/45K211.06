using IDM_Project.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IDM_Project.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}