using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datarynx
{
#pragma warning disable S1118 // Utility classes should not have public constructors
    public class Startup
#pragma warning restore S1118 // Utility classes should not have public constructors
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            var serviceProvider =
                new ServiceCollection()
                     .ConfigureServices()
                    .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}
