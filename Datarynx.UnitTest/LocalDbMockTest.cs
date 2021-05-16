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

    public class LocalDbMockTest
    {
        private readonly Mock<IToDoItemRepository> _toDoItemRepository = new Mock<IToDoItemRepository>();
      
        [Fact]
        public async Task GetItemAsync_ShouldReturn_WhenToDolistExits_TestAsync()
        {
            //Arrange
            List<ToDoItem> items = new List<ToDoItem>();

            items.Add(new LocalDB.Models.ToDoItem());
            items.Add(new LocalDB.Models.ToDoItem());
            items.Add(new LocalDB.Models.ToDoItem());

            _toDoItemRepository.Setup(c => c.GetItemAsync(string.Empty)).ReturnsAsync(items);

            //Act
            var reslt =await _toDoItemRepository.Object.GetItemAsync("");

            //Assert
            Assert.True(reslt.Count>0);

        }

        [Fact]
        public async Task AddItemAsync_ShouldReturnId_WhenItem_TestAsync()
        {

            ToDoItem toDoItem = new ToDoItem();
            toDoItem.ToDoItemID = 12;
            toDoItem.StoreName = "Store Test";

            //Setup
            _toDoItemRepository.Setup(c => c.AddItemAsync(toDoItem)).ReturnsAsync(10);

            //Act
            var reslt = await _toDoItemRepository.Object.AddItemAsync(toDoItem);

            //Assert
            Assert.True(reslt > 0);

        }
        

    }
}
