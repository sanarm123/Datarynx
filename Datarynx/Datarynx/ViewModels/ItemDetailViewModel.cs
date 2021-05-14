using Datarynx.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {

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
                var item = await ToDoItemDataRepository.GetItemAsync(int.Parse(itemId));

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
