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
    public partial class InformDetail : ContentPage
    {
        public InformDetail()
        {
            InitializeComponent();
        }
        Models.InformModel _inform;
        public InformDetail(Models.InformModel inform)
        {
            InitializeComponent();
            Title = "Edit Inform";
            _inform = inform;
            titleEntry.Text = inform.Title;
            enterEntry.Text = inform.Enter;
            titleEntry.Focus();
        }

        async void Button_Send(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleEntry.Text) || string.IsNullOrWhiteSpace(enterEntry.Text))
            {
                await DisplayAlert("Invalid", "Blank or WhiteSapce value is Invalid!", "OK");
            }
            else if (_inform != null)
            {
                EditInform();
            }
            else
                AddNewInform();
        }

        async void AddNewInform()
        {
            await App.MyDatabase.CreateInform(new Models.InformModel
            {
                Title = titleEntry.Text,
                Enter = enterEntry.Text
            });
            await Navigation.PopAsync();
        }
        async void EditInform()
        {
            _inform.Title = titleEntry.Text;
            _inform.Enter = enterEntry.Text;
            await App.MyDatabase.UpdateInform(_inform);
            await Navigation.PopAsync();
        }
    }
}
