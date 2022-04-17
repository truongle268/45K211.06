using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace IMD.Models
{
    public class ShowInfoModel
    {
        [PrimaryKey, AutoIncrement]
        public string HoTen { get; set; }
        public string MaSV { get; set; }
        public string BienSo { get; set; }
        public string DongXe { get; set; }
        public string MauXe { get; set; }
        public string MatKhau { get; set; }

    }
}
