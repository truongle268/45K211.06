using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace IMD.Models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<Mainpage> Mainpages;

        public ObservableCollection<Mainpage> mainpages
        {
            get { return Mainpages; }
            set
            {
                Mainpages = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mainpage"));
            }
        }


        public MainViewModel()
        {
            mainpages = new ObservableCollection<Mainpage>();
            addData();
        }

        private void addData()
        {
            mainpages.Add(new Mainpage
            {

                id = 0,
                title = "Gói tuần",
                imgSource = "https://fv9-3.failiem.lv/thumb_show.php?i=h776vgdmt&view"
            });
            mainpages.Add(new Mainpage
            {

                id = 0,
                title = "Gói tháng",
                imgSource = "https://fv9-6.failiem.lv/thumb_show.php?i=aeucbyja2&view"
            });
            mainpages.Add(new Mainpage
            {

                id = 0,
                title = "Gói kỳ",
                imgSource = "https://fv9-4.failiem.lv/thumb_show.php?i=2pkbs3heq&view"
            });
        }
    }
}