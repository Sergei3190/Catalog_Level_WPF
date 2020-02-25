using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Catalog_Level_WPF_Model.Models;

namespace Catalog_Level_WPF_Model.ViewModels
{
    public class CatalogLevelViewModel: INotifyPropertyChanged
    {
        private int id;
        private string name;
        private List<CatalogLevelViewModel> childs;
        private bool isSelected;
        public static string SelectedName { get; set; }
        public static object SelectedItem { get; set; }

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public List<CatalogLevelViewModel> Childs 
        { 
            get => childs;     
            set
            { 
                childs = value;
                OnPropertyChanged();
            }        
        }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged();
                    if (isSelected)
                    {
                        SelectedItem = this;
                        SelectedName = this.Name;
                    }
                }              
            }
        }

        public CatalogLevelViewModel() { }
  
        public CatalogLevelViewModel(int id, string name, params CatalogLevelViewModel[] models)
        {
            ID = id;
            Name = name;
            Childs = models.ToList();
        }

        public override string ToString() => $"{nameof(ID)} = {ID}, " +
                                             $"{nameof(Name)} = {Name}, " +
                                             $"{nameof(Childs)} = {Childs.Count}";
     
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
