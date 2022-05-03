using IMD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMD.ViewModels
{
    public class DeliveryInformViewModel : BaseViewModel
    {
        private bool _IsAdmin;
        public bool IsAdmin { get => _IsAdmin; set { _IsAdmin = value; OnPropertyChanged(); } }
        public DeliveryInformViewModel()
        {
            IsAdmin = Constants.IsAdmin;
        }
    }
}
