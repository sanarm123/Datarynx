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

        private readonly Mock<IToDoItemRepository> itodoRepo = new Mock<IToDoItemRepository>();
        public ItemDetailViewModelTest()
        {
            var platformServicesFake = A.Fake<IPlatformServices>();
            Device.PlatformServices = platformServicesFake;

            _itemsViewModel = new ItemDetailViewModel();
        }

        [Fact]
        public void Verify_Text_Not_Null_Test()
        {
            _itemsViewModel.StoreName = "Details View Model";

            Assert.NotNull(_itemsViewModel.StoreName);

        }

        [Fact]
        public void Verify_StoreAddres_Not_Null_Test()
        {
            _itemsViewModel.StoreAddress = "Description";

            Assert.NotNull(_itemsViewModel.StoreAddress);

        }

        [Theory]
        [InlineData("Test Store Name")]
        public void Verify_StoreName_Length_Test(string storeName)
        {
            _itemsViewModel.StoreName =storeName;

            Assert.True(_itemsViewModel.StoreName.Length>0);

        }

        [Fact]
        public void Verify_Id_Not_Null_Test()
        {
            _itemsViewModel.ItemId = "1";

            Assert.NotNull(_itemsViewModel.ItemId);

        }

       

        

    }
}
