using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datarynx.Droid
{

    [Activity(Label = "Datarynx", Icon = "@mipmap/icon", Theme = "@style/Mytheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class SplashActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            try
            {

                var intent = new Intent(this, typeof(MainActivity));

                if (Intent.Extras != null)
                {
                    intent.PutExtras(Intent.Extras);
                }

                StartActivity(intent);
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex);

            }
        }
    }
}