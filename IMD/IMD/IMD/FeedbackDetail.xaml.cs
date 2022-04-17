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
    public partial class FeedbackDetail : ContentPage
    {
        public FeedbackDetail()
        {
            InitializeComponent();
        }
        Models.FeedbackModel _feedback;
        public FeedbackDetail(Models.FeedbackModel feedback)
        {
            InitializeComponent();
            Title = "Edit Feedback";
            _feedback = feedback;
            titleFBEntry.Text = feedback.TitleFB;
            enterFBEntry.Text = feedback.EnterFB;
            titleFBEntry.Focus();
        }

        async void Button_SendFB(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleFBEntry.Text) || string.IsNullOrWhiteSpace(enterFBEntry.Text))
            {
                await DisplayAlert("Invalid", "Blank or WhiteSapce value is Invalid!", "OK");
            }
            else if (_feedback != null)
            {
                EditFeedback();
            }
            else
                AddNewFeedback();
        }

        async void AddNewFeedback()
        {
            await App.MyDatabaseFB.CreateFeedback(new Models.FeedbackModel
            {
                TitleFB = titleFBEntry.Text,
                EnterFB = enterFBEntry.Text
            });
            await Navigation.PopAsync();
        }
        async void EditFeedback()
        {
            _feedback.TitleFB = titleFBEntry.Text;
            _feedback.EnterFB = enterFBEntry.Text;
            await App.MyDatabaseFB.UpdateFeedback(_feedback);
            await Navigation.PopAsync();
        }
    }
}