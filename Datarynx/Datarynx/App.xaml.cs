using Datarynx.LocalData;
using Datarynx.LocalDB.DBContext;
using Datarynx.Services;
using Datarynx.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Datarynx
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<SqlLiteDatabaseContext>();
            DependencyService.Register<IToDoItemDataRepository, ToDoItemDataRepository>();


            MainPage = new AppShell();
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
