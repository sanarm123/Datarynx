using Datarynx.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace Datarynx.UnitTest
{
   
    [ExcludeFromCodeCoverage]
    public class ItemDetailViewModelTest
    {
        private ItemDetailViewModel _itemsViewModel;
        public ItemDetailViewModelTest()
        {
            _itemsViewModel = new ItemDetailViewModel();
        }

        [Fact]
        public void Verify_Text_Not_Null_Test()
        {
            _itemsViewModel.Text = "Details View Model";

            Assert.NotNull(_itemsViewModel.Title);

        }

        [Fact]
        public void Verify_Description_Not_Null_Test()
        {
            _itemsViewModel.Description = "Description";

            Assert.NotNull(_itemsViewModel.Title);

        }


    }
}
