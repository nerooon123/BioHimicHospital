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
    
    public partial class LaboratoryAssistants
    {
        public int IdLaboratoryAssistant { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int IdLaboratoryService { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> Salary { get; set; }
        public Nullable<int> Ward { get; set; }
        public string Login { get; set; }
    
        public virtual LaboratoryServices LaboratoryServices { get; set; }
        public virtual Users Users { get; set; }
    }
}