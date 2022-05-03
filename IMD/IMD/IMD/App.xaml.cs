using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using IMD.Models;
namespace IMD
{
    public partial class App : Application
    {
        IAuth auth;
        private static SQLiteHelper db;
        public static SQLiteHelper MyDatabase
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "MyStore.db3"));
                }
                return db;
            }
        }
        private static SQLiteHelperFB dc;
        public static SQLiteHelperFB MyDatabaseFB
        {
            get
            {
                if (dc == null)
                {
                    dc = new SQLiteHelperFB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "MyStore.db3"));
                }
                return dc;
            }
        }

       
        public App()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            //MainPage = new MainPage();
            // thấy chỗ này vô nghĩa không? trả về true hay false đều load LoginUI()
            MainPage = new NavigationPage(new LoginUI());
            //   MainPage = new MyFlyoutPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
