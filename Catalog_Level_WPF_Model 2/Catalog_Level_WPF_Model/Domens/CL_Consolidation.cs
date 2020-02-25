using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Level_WPF_Model.Domens
{
    public class CL_Consolidation
    {
        public int ID { get; set; }
        public int? Parent_ID { get; set; } 
        public string Name { get; set; } 
        public int? Catalog_ID { get; set; } 
        public int? Aggregate_ID { get; set; } 
        public int? Aggregate_catalog_ID { get; set; } 
        public int? Model_aggregate_ID { get; set; } 

        public override string ToString() => $"{nameof(ID)}: {ID}, " +
                                             $"{nameof(Parent_ID)}: {Parent_ID}, " +
                                             $"{nameof(Name)}: {Name}, " +
                                             $"{nameof(Catalog_ID)}: {Catalog_ID}, " +
                                             $"{nameof(Aggregate_ID)}: {Aggregate_ID}, " +
                                             $"{nameof(Aggregate_catalog_ID)}: {Aggregate_catalog_ID}, " +
                                             $"{nameof(Model_aggregate_ID)}: {Model_aggregate_ID}";
    }
}
