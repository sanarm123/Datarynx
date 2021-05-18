using Datarynx.LocalDB.Repository;
using Microsoft.AppCenter.Crashes;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private readonly IToDoItemRepository _toDoItemDataRepository;
        private string _itemId;
        private string _storeName;
        private string _storeAddress;

        public ItemDetailViewModel(IToDoItemRepository toDoItemDataRepository)
        {
            _toDoItemDataRepository = toDoItemDataRepository;

        }

   
        public string Id { get; set; }

        public string StoreName
        {
            get => _storeName;
            set => SetProperty(ref _storeName, value);
        }

        
        public string StoreAddress
        {
            get => _storeAddress;
            set => SetProperty(ref _storeAddress, value);
        }

        public string ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public virtual async void LoadItemId(string itemId)
        {
            try
            {
                Title = "Details";
                var item = await _toDoItemDataRepository.GetItemAsync(int.Parse(itemId));

                Id = item.ToDoItemID.ToString();
                StoreName = item.StoreName;
                StoreAddress = item.StoreAddress;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }
    }
}
