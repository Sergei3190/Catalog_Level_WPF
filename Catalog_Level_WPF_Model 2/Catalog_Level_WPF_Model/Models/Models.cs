//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Catalog_Level_WPF_Model.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Models
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AggregateID { get; set; }
    
        public virtual Aggregates Aggregates { get; set; }
    }
}
