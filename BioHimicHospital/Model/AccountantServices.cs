//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BioHimicHospital.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountantServices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountantServices()
        {
            this.Accountants = new HashSet<Accountants>();
        }
    
        public int IdAccountantService { get; set; }
        public string NameAccountantService { get; set; }
        public int PeriodOfExecution { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Accountants> Accountants { get; set; }
    }
}
