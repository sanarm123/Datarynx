using Datarynx.LocalDB.Repository;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private readonly IToDoItemRepository _toDoItemDataRepository;

        public ItemDetailViewModel(IToDoItemRepository toDoItemDataRepository = null)
        {
            _toDoItemDataRepository = toDoItemDataRepository == null ? DependencyService.Get<IToDoItemRepository>() : toDoItemDataRepository;
        }

        private string itemId;
        private string storeName;
      
        private string storeAddress;
        public string Id { get; set; }

        public string StoreName
        {
            get => storeName;
            set => SetProperty(ref storeName, value);
        }

        
        public string StoreAddress
        {
            get => storeAddress;
            set => SetProperty(ref storeAddress, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
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
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
