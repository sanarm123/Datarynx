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
        private ItemsViewModel _itemsViewModel;
        private readonly Mock<IToDoItemRepository> _toDoItemRepository=new Mock<IToDoItemRepository>();
        public ItemsViewModelTest()
        {
            var platformServicesFake = A.Fake<IPlatformServices>();
            Device.PlatformServices = platformServicesFake;

           

            _itemsViewModel = new ItemsViewModel(_toDoItemRepository.Object);
        }

        [Fact]
        public void LoadItemsCommand_Not_Null_Test()
        {
              
            Assert.NotNull(_itemsViewModel.LoadItemsCommand);
        }

        [Fact]
        public void LoadItemsCommand_Not_Null_Execute_Test()
        {
            //Arrange
            _itemsViewModel.SelectedSort =new Helpers.PickerElement() { 
                PropertyDisplayName="StoreName",
                 PropertName ="StoreName" 
            };
            _itemsViewModel.Items.Add(new ToDoItem());
            _itemsViewModel.Items.Add(new ToDoItem());
            _itemsViewModel.Items.Add(new ToDoItem());

            List<ToDoItem> items = new List<ToDoItem>();

            items.Add(new LocalDB.Models.ToDoItem());
            items.Add(new LocalDB.Models.ToDoItem());
            items.Add(new LocalDB.Models.ToDoItem());

            _toDoItemRepository.Setup(x => x.GetItemAsync("")).ReturnsAsync(items);

            var RESULT = _toDoItemRepository.Object.GetItemAsync("");
            //Act
            _itemsViewModel.LoadItemsCommand.Execute(null);

            //Assert
            Assert.NotNull(_itemsViewModel.LoadItemsCommand);


        }

        [Fact]
        public void ItemTapped_Not_Null_Test()
        {

            Assert.NotNull(_itemsViewModel.ItemTapped);
        }

        

        [Fact]
        public void OnSearchBarcClicked_Test()
        {
            var itemsViewModel = new ItemsViewModel();
            Assert.NotNull(_itemsViewModel.ShowSearchBar);
        }
    }
}
