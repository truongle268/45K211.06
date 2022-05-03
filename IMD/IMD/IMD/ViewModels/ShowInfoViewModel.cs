using IMD.Models;
using IMD.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace IMD.ViewModels
{
    public class ShowInfoViewModel : BaseViewModel
    {
        private User _Userr;
        public User Userr { get => _Userr; set { _Userr = value; OnPropertyChanged(); } }

        private ShowInfo _ShowInfoWindow;
        public ShowInfo ShowInfoWindow { get => _ShowInfoWindow; set { _ShowInfoWindow = value; OnPropertyChanged(); } }

        public Command UpdateUserInfo { get; set; }
        public ShowInfoViewModel(ShowInfo showInfo)
        {
            ShowInfoWindow = showInfo;
            FirstLoad();
            LoadCommand();
        }

        private void LoadCommand()
        {
            UpdateUserInfo = new Command(async () =>
            {
                bool isOk = await UserInfoUtilities.UpdateUserInfo(Userr, (o) => 
                {
                    ShowInfoWindow.DisplayAlert("Thông báo", o, "OK");
                });
                if (isOk)
                {
                    ShowInfoWindow.DisplayAlert("Thông báo", "Cập nhật thông tin thành công!", "OK");
                }
            });
        }

        private async void FirstLoad()
        {
            Userr = await UserInfoUtilities.GetUserInfo(Constants.Uid, (s) => { });
        }


    }

}
