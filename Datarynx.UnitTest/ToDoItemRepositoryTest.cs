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

        [Theory]
        [InlineData(null)]
        public async Task AddItemAsync_ThrowsArgumentException_Test(ToDoItem val)
        {
            //arrange
            IToDoItemRepository repo = new ToDoItemRepository();

            await Assert.ThrowsAsync<NullReferenceException>(() => repo.AddItemAsync(val));
        }

        [Fact]
        public async Task GetItemAsync_Call_Test()
        {
            IToDoItemRepository repo = new ToDoItemRepository();

            var repoRes = await repo.GetItemAsync("wk");

            Assert.NotNull(repoRes);

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
