
using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Models;
using Datarynx.LocalDB.Repository;
using Datarynx.Models;
using Datarynx.Services;
using Datarynx.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Datarynx
{
    public partial class App : Application
    {

        public  App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<SqlLiteDatabaseContext>();
            
            //Resolve DBContext
            var dataRepository =DependencyService.Get<SqlLiteDatabaseContext>();

            //Register Repository
            DependencyService.RegisterSingleton<IToDoItemRepository>(new ToDoItemRepository(dataRepository));

            MainPage = new AppShell();

            var itemsReository= DependencyService.Get<IToDoItemRepository>();

            
            var items= itemsReository.GetItemAsync().Result;

            if (items.Count==0) {

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
                             WeekNo=item.WeekNo,
                             StoreName=item.StoreName,
                             TaskStatus=item.TaskStatus,
                             CodingType=item.CodingType,
                             CreateDate=DateTime.Now,
                             StoreAddress=item.StoreAddress,
                             WeekDate=item.WeekDate
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
            //Method is empty has its not implemeted.
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
