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
    
    public partial class Aggregates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aggregates()
        {
            this.Models = new HashSet<Models>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int CatalogID { get; set; }
    
        public virtual Catalogs Catalogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Models> Models { get; set; }
    }
}
