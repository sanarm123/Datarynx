using Datarynx.Helpers;
using Datarynx.LocalDB.Models;
using Datarynx.LocalDB.Repository;
using Datarynx.ViewModels;
using FakeItEasy;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xunit;

namespace Datarynx.UnitTest
{
    [ExcludeFromCodeCoverage]
    public class ItemsViewModelTest
    {
        private readonly ItemsViewModel _itemsViewModel;
        private readonly Mock<IToDoItemRepository> _toDoItemRepository=new Mock<IToDoItemRepository>();
        public ItemsViewModelTest()
        {
            var platformServicesFake = A.Fake<IPlatformServices>();
            Device.PlatformServices = platformServicesFake;

            List<ToDoItem> items = new List<ToDoItem>();

            items.Add(new LocalDB.Models.ToDoItem() { ToDoItemID=1, StoreName = "Test" });
            items.Add(new LocalDB.Models.ToDoItem() { ToDoItemID=2, StoreName = "Test2" });
            items.Add(new LocalDB.Models.ToDoItem() { ToDoItemID=3, StoreName = "Test3" });

            _toDoItemRepository.Setup(x => x.GetItemAsync("wk")).ReturnsAsync(items);

            _itemsViewModel = new ItemsViewModel(_toDoItemRepository.Object);
        }

        [Fact]
        public void LoadItemsCommand_Not_Null_Test()
        {
              
            Assert.NotNull(_itemsViewModel.LoadItemsCommand);
        }

        [Fact]
        public void OnSearchClick_Not_Null_Test()
        {

            Assert.NotNull(_itemsViewModel.ShowSearchBar);
        }


      
        [Theory]
        [InlineData("StoreName","Store Name")]
        public void LoadItemsCommand_GetResults_Test(string propertyName, string displayName)
        {
            //Arrange
            _itemsViewModel.SelectedSort = new Helpers.PickerElement()
            {   PropertyDisplayName = displayName,
                PropertName = propertyName
            };

            _itemsViewModel.SearchCriteria = "wk";
           
            //Act
            _itemsViewModel.LoadItemsCommand.Execute(null);

            //Assert
            Assert.True(_itemsViewModel.Items.Count>0);

        }

        [Fact]
        public void ItemTapped_Not_Null_Test()
        {

            Assert.NotNull(_itemsViewModel.ItemTapped);
        }

        

        [Fact]
        public void OnSearchBarcClicked_Test()
        {
            Assert.NotNull(_itemsViewModel.ShowSearchBar);
        }


        [Fact]
        public void OnSortCommandClicked_Test()
        {
            _itemsViewModel.SelectedSort = new Helpers.PickerElement()
            {
                PropertyDisplayName = "StoreName",
                PropertName = "StoreName"
            };
            _itemsViewModel.IsAscending = true;
            _itemsViewModel.Items.Add(new ToDoItem());
            _itemsViewModel.Items.Add(new ToDoItem());
            _itemsViewModel.Items.Add(new ToDoItem());

            List<ToDoItem> items = new List<ToDoItem>();

            items.Add(new LocalDB.Models.ToDoItem() { StoreName = "Test" });
            items.Add(new LocalDB.Models.ToDoItem() { StoreName = "Test2" });
            items.Add(new LocalDB.Models.ToDoItem() { StoreName = "Test3" });

            _toDoItemRepository.Setup(x => x.GetItemAsync("")).ReturnsAsync(items);


             _toDoItemRepository.Object.GetItemAsync("");

            _itemsViewModel.SortCommand.Execute(null);

            Assert.NotNull(_itemsViewModel.SortCommand);
        }

      
    }
}
