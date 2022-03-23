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
    public partial class Tickets : ContentPage
    {
        public Tickets()
        {
            InitializeComponent();

            TicketPicker.Items.Add("Gói tuần");
            TicketPicker.Items.Add("Gói tháng");
            TicketPicker.Items.Add("Gói kỳ");

        }
        private void TicketPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var name = TicketPicker.SelectedIndex;
            DisplayAlert("Thông báo!", "Bạn có muốn chọn gói?", "OK");
        }
    }
}
