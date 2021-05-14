using Datarynx.ViewModels;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Datarynx.UnitTest
{
    [ExcludeFromCodeCoverage]
    public class ItemsViewModelTest
    {
        private ItemsViewModel _itemsViewModel;
        public ItemsViewModelTest()
        {
            _itemsViewModel = new ItemsViewModel();
        }

        [Fact]
        public void LoadItemsCommand_Not_Null_Test()
        {
           
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
