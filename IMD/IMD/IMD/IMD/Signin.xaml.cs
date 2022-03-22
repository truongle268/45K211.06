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

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Sẽ có thêm đoạn code jj đó để mà đẩy dữ liệu qua sql 
            DisplayAlert("Thông báo", "Tài khoản đã được đăng ký thành công, vui lòng thanh toán các gói vé cho quản trị viên để kích hoạt tài khoản", "Cancel");

        }
    }
}