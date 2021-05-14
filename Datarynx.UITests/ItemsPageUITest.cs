using System;
using System.IO;
using System.Linq;
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
        Platform platform;

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
        public void ToDoItemsPageIsDisplayed()
        {
          
            app.Query(c => c.Marked("SortedBy"));

            app.Screenshot("To Do List Screen.");


            Assert.IsTrue(true);
        }
    }
}
