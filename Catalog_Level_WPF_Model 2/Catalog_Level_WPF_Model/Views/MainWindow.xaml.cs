using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Catalog_Level_WPF_Model.Models;
using Catalog_Level_WPF_Model.ViewModels;

namespace Catalog_Level_WPF_Model.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TreeViewViewModel();
            #region delegate
            //btnFillTreeView.Click += delegate
            //{
            //    //реализовать очистку дерева перед заполнением
            //    treeView_Catalov_Level.ItemsSource = new TreeViewViewModel();
            //};     
            #endregion
        }
    }
}
