using Datarynx.Helpers;
using Datarynx.LocalDB.Models;
using Datarynx.LocalDB.Repository;
using Datarynx.Views;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{
    /// <summary>
    /// Items view model viewmodel
    /// </summary>
    public class ItemsViewModel : BaseViewModel
    {
        #region Private Properties
        private readonly IToDoItemRepository _toDoItemDataRepository;
        private ToDoItem _selectedItem;
        private string _searchCriteria;
        private PickerElement _selectedSort;
        private bool? _showSearchBarSection = false;
        private bool _isAscending;
        public ObservableCollection<PickerElement> PickerElemetsCollection { get; }
        #endregion

        #region Commands
        public ObservableCollection<ToDoItem> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command SortCommand { get; }
        public Command ShowSearchBar { get; }
        public Command<ToDoItem> ItemTapped { get; }
        #endregion

        /// <summary>
        /// Items View Model constructor
        /// </summary>
        /// <param name="toDoItemDataRepository">ToDoItemRepository Interface</param>
        public ItemsViewModel(IToDoItemRepository toDoItemDataRepository)
        {
            _toDoItemDataRepository = toDoItemDataRepository;
            Items = new ObservableCollection<ToDoItem>();
            PickerElemetsCollection = new ObservableCollection<PickerElement>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SortCommand = new Command(() => ExecuteSortCommand());
            ShowSearchBar = new Command(OnSearchBarcClicked);
            ItemTapped = new Command<ToDoItem>(OnItemSelected);

            Title = "To-Do List";
            SetSortPickerColums();

        }

   
        public string SearchCriteria
        {
            get => _searchCriteria;
            set
            {
                SetProperty(ref _searchCriteria, value);
                FillItems();
            }
        }
        public PickerElement SelectedSort
        {
            get => _selectedSort;
            set
            {
               
                SetProperty(ref _selectedSort, value);

                FillItems();

            }
        }
        public bool IsAscending
        {
            get => _isAscending;
            set
            {
                SetProperty(ref _isAscending, value);
            }
        }
        public bool? ShowSearchBarSection
        {
            get => _showSearchBarSection;
            set
            {
                SetProperty(ref _showSearchBarSection, value);

            }
        }
     
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            Analytics.TrackEvent("ExecuteLoadItemsCommand Called");

            try
            {
                Items.Clear();
                await SortItems();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public IQueryable<ToDoItem> GetItems(List<ToDoItem> list)
        {
            return list.AsQueryable();
        }
     
        /// <summary>
        /// Sort Method
        /// </summary>
        /// <returns></returns>
        private async Task SortItems()
        {
            Items.Clear();

            try
            {
                var todoListBySearchCritieria = await _toDoItemDataRepository.GetItemAsync(SearchCriteria);

                if (todoListBySearchCritieria != null)
                {
                    var sortedList = LinqHelper.OrderBy<ToDoItem>(GetItems(todoListBySearchCritieria), SelectedSort != null ? SelectedSort.PropertName : PickerElemetsCollection[0].PropertName, IsAscending);

                    foreach (var item in sortedList)
                    {
                        Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }

        }

        /// <summary>
        /// Read Model Properties dynamically
        /// </summary>
        private void SetSortPickerColums()
        {
            var info = TypeDescriptor.GetProperties(typeof(ToDoItem)).Cast<PropertyDescriptor>().ToDictionary(p => p.Name, p => p.DisplayName);

            foreach (var item in info)
            {
                PickerElemetsCollection.Add(new PickerElement() { PropertName = item.Key, PropertyDisplayName = item.Value });
            }
        }

        private void ExecuteSortCommand()
        {
            if (IsAscending)
            {
                IsAscending = false;
            }
            else
            {
                IsAscending = true;
            }

            FillItems();
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        private void FillItems()
        {
            Task.Run(async () =>
            {
                await ExecuteLoadItemsCommand();
            });
        }

        async void OnItemSelected(ToDoItem item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.ToDoItemID}");
        }

        private void OnSearchBarcClicked(object obj)
        {

            if (ShowSearchBarSection == false)
            {
                ShowSearchBarSection = true;

            }
            else
            {
                ShowSearchBarSection = false;

            }
        }

        public ToDoItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

    }
}