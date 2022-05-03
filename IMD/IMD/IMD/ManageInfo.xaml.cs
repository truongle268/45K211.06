using IMD.Models;
using IMD.Utilities;
using IMD.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageInfo : ContentPage
    {
        public ManageInfoViewModel ViewModel { get; set; }
        public ManageInfo()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ManageInfoViewModel(this);
        }


    }
}