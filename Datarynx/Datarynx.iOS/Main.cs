using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Datarynx.iOS
{
#pragma warning disable S1118 // Utility classes should not have public constructors
    public class Application
#pragma warning restore S1118 // Utility classes should not have public constructors
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
