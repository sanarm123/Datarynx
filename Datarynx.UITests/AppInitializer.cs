using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Datarynx.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.datarynx.todolist").StartApp();
            }

            return ConfigureApp.iOS.InstalledApp("com.datarynx.todolist").StartApp();
        }
    }
}