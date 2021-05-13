
using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Repository;
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
            
            //Resolve DBContext
            var dataRepository =DependencyService.Get<SqlLiteDatabaseContext>();

            //Register Repository
            DependencyService.RegisterSingleton<IToDoItemRepository>(new ToDoItemRepository(dataRepository));

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
