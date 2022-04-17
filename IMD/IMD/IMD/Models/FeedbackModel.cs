using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace IMD.Models
{
    public class FeedbackModel
    {
        [PrimaryKey, AutoIncrement]
        public int IDFB { get; set; }
        [MaxLength(50)]
        public string TitleFB { get; set; }
        public string EnterFB { get; set; }
    }
}