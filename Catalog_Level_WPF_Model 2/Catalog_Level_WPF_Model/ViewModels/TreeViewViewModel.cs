using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog_Level_WPF_Model.Models;
using Catalog_Level_WPF_Model.Domens;
using Catalog_Level_WPF_Model;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Catalog_Level_WPF_Model.ViewModels
{
    public class TreeViewViewModel : IEnumerable<CatalogLevelViewModel>, INotifyPropertyChanged
    {
        private ObservableCollection<CatalogLevelViewModel> catalogLevelViewModels;
        private string valueTextBox;

        public ObservableCollection<CatalogLevelViewModel> CatalogLevelViewModels
        {
            get => catalogLevelViewModels;
            set
            {
                catalogLevelViewModels = value;
                OnPropertyChanged();
            }
        }

        public string ValueTextBox
        {
            get => valueTextBox;
            set
            {
                valueTextBox = value;
                OnPropertyChanged();
            }
        }

        public ICommand FillTreeNodes { get; private set; } // private set - тк мы не планируем менять поведение команды
        public ICommand DeleteTreeNodes { get; private set; }
        public ICommand SelectNode { get; private set; }
        public ICommand SaveNodeСhanges { get; private set; }
        public ICommand DeleteNode { get; private set; }
        public ICommand AddNode { get; private set; }


        public TreeViewViewModel()
        {
            DataInitializer();
            LoadData();
            LoadCommand();
        }

        void DataInitializer()
        {
            CatalogLevelModel.DataInitializer();
        }

        void LoadData()
        {
            var catalogLevels = CatalogLevelModel.LoadCatalogLevels();
            CatalogLevelViewModels = CatalogLevelDomen.GetCatalogLevelViewModels(catalogLevels);
        }

        void LoadCommand()
        {
            FillTreeNodes = new DelegateCommand(AddItemsSource);
            DeleteTreeNodes = new DelegateCommand(DeleteItemsSource);
            SelectNode = new DelegateCommand(SelectItem);
            SaveNodeСhanges = new DelegateCommand(SaveItemChanges);
            DeleteNode = new DelegateCommand(DeleteItem);
            AddNode = new DelegateCommand(AddItem);
        }

        void AddItemsSource(object obj)
        {
            LoadData();
        }

        void DeleteItemsSource(object obj)
        {
            CatalogLevelViewModels.Clear();
        }

        private void SelectItem(object obj)
        {
            ValueTextBox = CatalogLevelViewModel.SelectedName;
        }

        void SaveItemChanges(object obj)
        {
            var item = CatalogLevelViewModel.SelectedItem;
            if (item is CatalogLevelViewModel viewModel)
            {
                UpdateData(viewModel);
            }
        }

        void DeleteItem(object obj)
        {
            var item = CatalogLevelViewModel.SelectedItem;
            if (item is CatalogLevelViewModel viewModel)
            {
                RemoveData(viewModel);
            }
        }

        void AddItem(object obj)
        {
            var item = CatalogLevelViewModel.SelectedItem;
            if (item is CatalogLevelViewModel viewModel)
            {
                AddData(viewModel, ValueTextBox);
            }
        }

        void UpdateData(CatalogLevelViewModel viewModel)
        {
            viewModel.Name = ValueTextBox;
            var catalogLevels = CatalogLevelModel.UpdateCatalogLevel(viewModel);
            CatalogLevelViewModels = CatalogLevelDomen.GetCatalogLevelViewModels(catalogLevels);
        }

        void RemoveData(CatalogLevelViewModel viewModel)
        {
            var catalogLevels = CatalogLevelModel.RemoveCatalogLevel(viewModel.ID);
            CatalogLevelViewModels = CatalogLevelDomen.GetCatalogLevelViewModels(catalogLevels);
            ValueTextBox = string.Empty;
        }

        void AddData(CatalogLevelViewModel viewModel, string valueTextBox)
        {
            var catalogLevels = CatalogLevelModel.AddCatalogLevel(viewModel, valueTextBox);
            CatalogLevelViewModels = CatalogLevelDomen.GetCatalogLevelViewModels(catalogLevels);
        }

        public IEnumerator<CatalogLevelViewModel> GetEnumerator()
        {
            return ((IEnumerable<CatalogLevelViewModel>)CatalogLevelViewModels).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<CatalogLevelViewModel>)CatalogLevelViewModels).GetEnumerator();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
