using Datarynx.LocalDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Xunit;

namespace Datarynx.UnitTest
{
    [ExcludeFromCodeCoverage]
    public class LinqHelperTest
    {
      

        [Fact]
        public void OrderBy_Items_Ascending_Test()
        {
            List<ToDoItem> items = new List<ToDoItem>();

            items.Add(new LocalDB.Models.ToDoItem() { StoreName = "Test" });
            items.Add(new LocalDB.Models.ToDoItem() { StoreName = "Test2" });
            items.Add(new LocalDB.Models.ToDoItem() { StoreName = "Test3" });

            var result = Helpers.LinqHelper.OrderBy<ToDoItem>(GetItems(items), "StoreName", true);
            int count = result.Count<ToDoItem>();
            Assert.True(count>0);
        }

        public IQueryable<ToDoItem> GetItems(List<ToDoItem> list)
        {
            return list.AsQueryable();

        }

    }
}
