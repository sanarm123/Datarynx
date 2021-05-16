using Datarynx.Helpers;
using Datarynx.LocalDB.Models;
using Datarynx.LocalDB.Repository;
using Datarynx.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly IToDoItemRepository _toDoItemDataRepository;
        private ToDoItem _selectedItem;
        private string _searchCriteria;
        private PickerElement _selectedSort;
        private bool? _showSearchBarSection = false;
        private bool _isAscending;

        public ObservableCollection<PickerElement> PickerElemetsCollection { get; }
        public ObservableCollection<ToDoItem> Items { get; }

        public Command LoadItemsCommand { get; }
        public Command SortCommand { get; }
        public Command ShowSearchBar { get; }
        public Command<ToDoItem> ItemTapped { get; }


        public ItemsViewModel(IToDoItemRepository toDoItemDataRepository = null)
        {
            _toDoItemDataRepository = toDoItemDataRepository == null ? DependencyService.Get<IToDoItemRepository>() : toDoItemDataRepository;

            Title = "To-Do List";
            Items = new ObservableCollection<ToDoItem>();
            PickerElemetsCollection = new ObservableCollection<PickerElement>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SortCommand = new Command(() => ExecuteSortCommand());
            ShowSearchBar = new Command(OnSearchBarcClicked);
            ItemTapped = new Command<ToDoItem>(OnItemSelected);

            SetSortPickerColums();

        }

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



        public string SearchCriteria
        {
            get => _searchCriteria;
            set
            {
                SetProperty(ref _searchCriteria, value);
                FillItems();
            }
        }

        private void FillItems()
        {
            Task.Run(async () =>
            {
                await ExecuteLoadItemsCommand();
            });
        }

        public PickerElement SelectedSort
        {
            get => _selectedSort;
            set
            {
                //var currentSort = _selectedSort;
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

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                Items.Clear();

                await SortItems();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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

        private async Task SortItems()
        {
            Items.Clear();

            var tepItems = await _toDoItemDataRepository.GetItemAsync(SearchCriteria);

            if (tepItems != null)
            {
                var sortedList = LinqHelper.OrderBy<ToDoItem>(GetItems(tepItems), SelectedSort != null ? SelectedSort.PropertName : PickerElemetsCollection[0].PropertName, IsAscending);

                foreach (var item in sortedList)
                {
                    Items.Add(item);
                }
            }
        }

        private void AddItems(IOrderedEnumerable<ToDoItem> sortedList)
        {
            if (sortedList != null)
            {
                foreach (var item in sortedList)
                {
                    Items.Add(item);
                }
            }

        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
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


        async void OnItemSelected(ToDoItem item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.ToDoItemID}");
        }

    }
}