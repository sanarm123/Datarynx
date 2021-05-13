﻿using Datarynx.LocalDB.Models;
using Datarynx.Models;
using Datarynx.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private ToDoItem _selectedItem;

        public ObservableCollection<ToDoItem> Items { get; }
        public Command LoadItemsCommand { get; }

        public Command ShowSearchBar { get; }

        public Command<ToDoItem> ItemTapped { get; }

        private string searchCriteria;
        public string SearchCriteria
        {
            get =>searchCriteria;
            set
            {

                SetProperty(ref searchCriteria, value);
                FillItems();
            }
        }

        private void FillItems()
        {
            Items.Clear();
            Task.Run(async () =>
            {
                await ExecuteLoadItemsCommand();
            });
        }

        private string _selectedSort="BDD";
        public string SelectedSort
        {
            get => _selectedSort;
            set
            {
                var currentSort = _selectedSort;
                SetProperty(ref _selectedSort, value);
                if (_selectedSort != currentSort)
                {
                    FillItems();
                }
            }
        }

       
        public ItemsViewModel()
        {
            Title = "To-Do List";
            Items = new ObservableCollection<ToDoItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ShowSearchBar = new Command(OnSearchBarcClicked);
            ItemTapped = new Command<ToDoItem>(OnItemSelected);
          
        }

        private bool? _showSearchBarSection = false;
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
            // throw new NotImplementedException();

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

        private async Task SortItems()
        {


            Items.Clear();

            var items = await ToDoItemDataRepository.GetItemAsync(SearchCriteria);


            if (SelectedSort == "BDD")
            {
                var sortedList = items.OrderBy(c => c.StoreName);
                foreach (var item in sortedList)
                {
                    Items.Add(item);
                }
            }
            else if(SelectedSort=="ASC")
            {
                var sortedList = items.OrderBy(c => c.ToDoItemID);
                foreach (var item in sortedList)
                {
                    Items.Add(item);
                }

            }
            else if (SelectedSort == "DESC")
            {
                var sortedList = items.OrderByDescending(c => c.ToDoItemID);
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

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.ToDoItemID}");
        }
    }
}