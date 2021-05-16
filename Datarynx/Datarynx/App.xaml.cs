
using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Models;
using Datarynx.LocalDB.Repository;
using Datarynx.Models;
using Datarynx.ViewModels;
using Datarynx.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;


using Xamarin.Forms;

namespace Datarynx
{
  
    public partial class App : Application
    {
        [ExcludeFromCodeCoverage]
        public  App()
        {
            InitializeComponent();

            DependencyService.Register<SqlLiteDatabaseContext>();

            DependencyService.RegisterSingleton<IToDoItemRepository>(new ToDoItemRepository(DependencyService.Get<SqlLiteDatabaseContext>()));

            MainPage = new AppShell();

           
        }

        [ExcludeFromCodeCoverage]
        private static void SetupData()
        {
            var itemsReository = DependencyService.Get<IToDoItemRepository>();

            var items = itemsReository.GetItemAsync(string.Empty).Result;

            if (items.Count == 0)
            {

                string jsonFileName = "todolistjson.json";
                var assembly = typeof(ItemsPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();

                    var RootObject = JsonConvert.DeserializeObject<Root>(jsonString);


                    foreach (var item in RootObject.ListItems)
                    {
                        itemsReository.AddItemAsync(new ToDoItem()
                        {
                            WeekNo = item.WeekNo,
                            StoreName = item.StoreName,
                            TaskStatus = item.TaskStatus,
                            CodingType = item.CodingType,
                            CreateDate = DateTime.Now,
                            StoreAddress = item.StoreAddress,
                            WeekDate = item.WeekDate
                        });

                    }

                }
            }
        }

        /// <summary>
        /// OnStart method
        /// </summary>
        protected override void OnStart()
        {
            AppCenter.Start("android=48e6569c-ce8a-48b0-8f39-21f7bc023868;" +
                   "uwp={Your UWP App secret here};" +
                   "ios={Your iOS App secret here}",
                   typeof(Analytics), typeof(Crashes));


            Analytics.SetEnabledAsync(true);
            Crashes.SetEnabledAsync(true);

        }

        /// <summary>
        /// OnSleep method
        /// </summary>
        protected override void OnSleep()
        {
            //Method is empty has its not implemeted.
        }

        /// <summary>
        /// OnResume method
        /// </summary>
        protected override void OnResume()
        {

            //Method is empty has its not implemeted.
        }
    }
}
