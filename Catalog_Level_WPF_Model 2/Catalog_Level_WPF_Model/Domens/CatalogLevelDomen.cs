using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog_Level_WPF_Model.Models;
using Catalog_Level_WPF_Model.ViewModels;

namespace Catalog_Level_WPF_Model.Domens
{
    public class CatalogLevelDomen
    {
        public static ObservableCollection<CatalogLevelViewModel> GetCatalogLevelViewModels(List<Catalog_level> catalog_Levels)
        {
            var catalogLevelsViewModels = new ObservableCollection<CatalogLevelViewModel>();

            foreach (var item in catalog_Levels)
            {
                if (item.ParentID.ToString() == string.Empty)
                {
                    catalogLevelsViewModels.Add(new CatalogLevelViewModel(item.ID, item.Name, AddChildNodes(item.ID, catalog_Levels)));
                }
            }

            return catalogLevelsViewModels;
        }

        private static CatalogLevelViewModel[] AddChildNodes(int id, List<Catalog_level> catalog_Levels)
        {
            var childs = new List<CatalogLevelViewModel>();

            foreach (var item in catalog_Levels)
            {
                if (item.ParentID.ToString() == id.ToString())
                {
                    childs.Add(new CatalogLevelViewModel(item.ID, item.Name, AddChildNodes(item.ID, catalog_Levels)));
                }
            }

            return childs.ToArray();
        }
    }
}
