using IMD.Models;
using IMD.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace IMD.ViewModels
{
    public class ManageInfoViewModel : BaseViewModel
    {
        public ObservableCollection<User> ListUser { get; set; } = new ObservableCollection<User>();

        private ManageInfo _ManageInfoWindow;
        public ManageInfo ManageInfoWindow { get => _ManageInfoWindow; set { _ManageInfoWindow = value; OnPropertyChanged(); } }


        public Command<object> OnClickUpdateInfo { get; set; }
        public Command<object> OnClickDeleteInfo { get; set; }
        public ManageInfoViewModel(ManageInfo manageInfo)
        {
            ManageInfoWindow = manageInfo;
            FirstLoad();
            LoadCommand();
        }

        private void LoadCommand()
        {
            OnClickUpdateInfo = new Command<object>(async (o) =>
            {
                User user = o as User;
                if (user != null)
                {
                    bool isOk = await UserInfoUtilities.UpdateUserInfo(user, (pp) =>
                    {
                        ManageInfoWindow.DisplayAlert("Thông báo", pp, "OK");
                    });
                    if (isOk)
                    {
                        ManageInfoWindow.DisplayAlert("Thông báo", "Cập nhật thông tin thành công!", "OK");
                    }
                }
            });
            OnClickDeleteInfo = new Command<object>(async (o) =>
            {
                User user = o as User;
                if (user != null)
                {
                    bool isOk = await UserInfoUtilities.DeleteUserInfo(user.Uid, (pp) =>
                    {
                        ManageInfoWindow.DisplayAlert("Thông báo", pp, "OK");
                    });
                    if (isOk)
                    {
                        ListUser.Remove(user);
                        ManageInfoWindow.DisplayAlert("Thông báo", "Xóa thông tin thành công!", "OK");
                    }
                }
            });
        }

        private async void FirstLoad()
        {
            ListUser = await UserInfoUtilities.GetUserInfos((s) => { });
            OnPropertyChanged(nameof(ListUser));
        }
    }

}
