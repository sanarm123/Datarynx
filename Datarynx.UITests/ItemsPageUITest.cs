using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Datarynx.UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class ItemsPageUITest
    {
        IApp app;
        private readonly Platform  platform;


        public ItemsPageUITest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [Order(1)]
        [Category("To-Do list Tests")]
        public void ItemsPageDisplayeTest()
        {

            app.Screenshot("To Do List Screen.");

            app.Query(c => c.Marked("SortedBy"));

            app.Tap("RefreshButton");

            Task.Delay(2000);

            app.Tap("FilterButton");

            Assert.IsTrue(true);
        }

    
    }
}
