using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog_Level_WPF_Model.ViewModels;

namespace Catalog_Level_WPF_Model.Models
{
    public class CatalogLevelModel
    {
        public static void DataInitializer()
        {
            var connect = new Catalog_Level_WPFContainer();

            if (!connect.Catalog_level.Any<Catalog_level>())
            {
                DataInitialization.Seed(connect);
            }
        }

        public static List<Catalog_level> LoadCatalogLevels()
        {
            using (var connect = new Catalog_Level_WPFContainer())
            {
                var catalogLevels = connect.Catalog_level.ToList();

                return catalogLevels;
            }
        }

        public static List<Catalog_level> RemoveCatalogLevel(int id)
        {
            using (var connect = new Catalog_Level_WPFContainer())
            {
                connect.Configuration.AutoDetectChangesEnabled = false;

                var catalogLevels = connect.Catalog_level.ToList();

                foreach (var item in catalogLevels)
                {
                    if (id == item.ID)
                    {
                        connect.Catalog_level.Remove(item);
                        connect.ChangeTracker.DetectChanges();
                        connect.SaveChanges();
                    }
                }

                var catalogLevelsNew = connect.Catalog_level.ToList();

                return catalogLevelsNew;
            }
        }

        public static List<Catalog_level> AddCatalogLevel(CatalogLevelViewModel viewModel, string valueTextBox)
        {
            using (var connect = new Catalog_Level_WPFContainer())
            {
                connect.Configuration.AutoDetectChangesEnabled = false;

                connect.Catalog_level.Add(new Catalog_level { Name = valueTextBox, ParentID = viewModel.ID });

                connect.ChangeTracker.DetectChanges();

                connect.SaveChanges();

                var catalogLevels = connect.Catalog_level.ToList();

                return catalogLevels;
            }
        }

        public static List<Catalog_level> UpdateCatalogLevel(CatalogLevelViewModel viewModel)
        {
            using (var connect = new Catalog_Level_WPFContainer())
            {
                // отключим авто отслеживание изменений в БД для улучшения производительности
                connect.Configuration.AutoDetectChangesEnabled = false;

                foreach (var item in connect.Catalog_level)
                {
                    if (item.ID == viewModel.ID)
                    {
                        item.Name = viewModel.Name;
                    }
                }

                // обнаружим изменения 
                connect.ChangeTracker.DetectChanges();

                connect.SaveChanges();

                var catalogLevels = connect.Catalog_level.ToList();

                return catalogLevels;

            }
        }
    }
}
