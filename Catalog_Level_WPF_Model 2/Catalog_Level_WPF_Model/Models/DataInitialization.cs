using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog_Level_WPF_Model.Domens;


namespace Catalog_Level_WPF_Model.Models
{
    public class DataInitialization
    {
        private static List<CL_Consolidation> cl_Consol = new List<CL_Consolidation>();

        public static void Seed(Catalog_Level_WPFContainer connect)
        {
            var catalogs = new List<Catalogs>()
                    {
                        new Catalogs{Name = "VOLVO"},
                        new Catalogs{Name = "ER"}
                    };

            catalogs.ForEach(x => connect.Catalogs.AddOrUpdate(c => new { c.Name }, x));

            var aggregates = new List<Aggregates>()
                    {
                        new Aggregates{Name = "КПП", Catalogs = catalogs[0]},
                        new Aggregates{Name = "Двигатель", Catalogs = catalogs[1]},
                        new Aggregates{Name = "КПП", Catalogs = catalogs[1]}
                    };
            aggregates.ForEach(x => connect.Aggregates.AddOrUpdate(a => new { a.Name, a.CatalogID }, x));

            var models = new List<Models>()
                    {
                        new Models{Name="A365", Aggregates = aggregates[0]},
                        new Models{Name="M4566", Aggregates = aggregates[1]},
                        new Models{Name="FG4511", Aggregates = aggregates[1]},
                        new Models{Name="T45459", Aggregates = aggregates[2]}
                    };
            models.ForEach(x => connect.Models.AddOrUpdate(m => new { m.Name, m.AggregateID }, x));
            connect.SaveChanges();

            var sampleCatalogs = connect.Catalogs.ToList();

            foreach (var item in sampleCatalogs)
            {
                cl_Consol.Add(new CL_Consolidation
                {
                    ID = (cl_Consol.Count) + 1,
                    Name = item.Name,
                    Catalog_ID = item.ID
                });
            }

            var sampleAggregates = connect.Aggregates.ToList();

            foreach (var item in sampleAggregates)
            {
                cl_Consol.Add(new CL_Consolidation
                {
                    ID = (cl_Consol.Count) + 1,
                    Name = item.Name,
                    Aggregate_ID = item.ID,
                    Aggregate_catalog_ID = item.CatalogID
                });
            }

            var sampleModels = connect.Models.ToList();

            foreach (var item in sampleModels)
            {
                cl_Consol.Add(new CL_Consolidation
                {
                    ID = (cl_Consol.Count) + 1,
                    Name = item.Name,
                    Model_aggregate_ID = item.AggregateID
                });
            }

            var selectCatalogsFromCl_Consol = from cl in cl_Consol
                                              where cl.Catalog_ID != null
                                              select new
                                              {
                                                  CLC_ID = cl.ID,
                                                  CLC_Parent_ID = cl.Parent_ID,
                                                  CLC_Name = cl.Name,
                                                  CLC_Catalog_ID = cl.Catalog_ID
                                              };

            var selectAggregatesFromCl_Consol = from cl in cl_Consol
                                                join c in selectCatalogsFromCl_Consol
                                                on cl.Aggregate_catalog_ID equals c.CLC_Catalog_ID
                                                where cl.Aggregate_catalog_ID != null
                                                select new
                                                {
                                                    CLA_ID = cl.ID,
                                                    CLA_Parent_ID = c.CLC_ID,
                                                    CLA_Name = cl.Name,
                                                    CLA_Aggregate_ID = cl.Aggregate_ID
                                                };

            var selectModelsFromCl_Consol = from cl in cl_Consol
                                            join a in selectAggregatesFromCl_Consol
                                            on cl.Model_aggregate_ID equals a.CLA_Aggregate_ID
                                            where cl.Model_aggregate_ID != null
                                            select new
                                            {
                                                CLM_ID = cl.ID,
                                                CLM_Parent_ID = a.CLA_ID,
                                                CLM_Name = cl.Name
                                            };

            foreach (var item in selectCatalogsFromCl_Consol)
            {
                connect.Catalog_level.Add(new Catalog_level
                {
                    ID = item.CLC_ID,
                    ParentID = item.CLC_Parent_ID,
                    Name = item.CLC_Name
                });
            }

            foreach (var item in selectAggregatesFromCl_Consol)
            {
                connect.Catalog_level.AddOrUpdate(new Catalog_level
                {
                    ID = item.CLA_ID,
                    ParentID = item.CLA_Parent_ID,
                    Name = item.CLA_Name
                });
            }

            foreach (var item in selectModelsFromCl_Consol)
            {
                connect.Catalog_level.AddOrUpdate(new Catalog_level
                {
                    ID = item.CLM_ID,
                    ParentID = item.CLM_Parent_ID,
                    Name = item.CLM_Name
                });
            }

            connect.SaveChanges();
        }
    }
}
