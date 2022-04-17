using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace IMD
{
    public partial class App : Application
    {
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
        private static SQLiteShowInfo de;
        public static SQLiteShowInfo MyDatabaseSI
        {
            get
            {
                if (de == null)
                {
                    de = new SQLiteShowInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "MyStore.de3"));
                }
                return de;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage( new LoginUI());
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
