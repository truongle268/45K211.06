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
    public partial class ShowInfo : ContentPage
    {
        public ShowInfoViewModel ViewModel { get; set; }
        public ShowInfo()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ShowInfoViewModel(this);
        }
        
    }
}