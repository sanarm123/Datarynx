using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Models;
using Datarynx.LocalDB.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Datarynx.UnitTest
{
    [ExcludeFromCodeCoverage]
    public  class ToDoItemRepositoryTest
    {
        [Fact]
        public async Task GetItemAsync_TEST()
        {
            
            var repos = new Mock<IToDoItemRepository>();

            var myList = new List<ToDoItem>();
            myList.Add(new ToDoItem());
            myList.Add(new ToDoItem());
            myList.Add(new ToDoItem());

            repos.Setup( x =>x.GetItemAsync("wk")).ReturnsAsync(myList);
            var output = await repos.Object.GetItemAsync("wk");
            Assert.Equal(3,output.Count);
        }
    }
}
