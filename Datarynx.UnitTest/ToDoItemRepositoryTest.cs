using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Models;
using Datarynx.LocalDB.Repository;

using FakeItEasy;
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
        public async Task GetItemAsync_Call_Test()
        {
            IToDoItemRepository rr = new ToDoItemRepository(new LocalDB.DBContext.SqlLiteDatabaseContext());

            var test = await rr.GetItemAsync("wk");

            Assert.NotNull(test);

        }

        [Fact]
        public void Model_Object_Not_NULL_Test()
        {
            ToDoItem todoItem = new ToDoItem();
            todoItem.StoreName = "Test";
            todoItem.TaskStatus = "Not Started";
            Assert.NotNull(todoItem);


        }
    }
}
