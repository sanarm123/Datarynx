using Datarynx.LocalDB.Repository;
using Datarynx.ViewModels;
using FakeItEasy;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xunit;

namespace Datarynx.UnitTest
{
   
    [ExcludeFromCodeCoverage]
    public class ItemDetailViewModelTest
    {
        private ItemDetailViewModel _itemsViewModel;
        public ItemDetailViewModelTest()
        {
            var platformServicesFake = A.Fake<IPlatformServices>();
            Device.PlatformServices = platformServicesFake;

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
