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
    
    public partial class Adminstrations
    {
        public int IdAdminstration { get; set; }
        public string Login { get; set; }
    
        public virtual Users Users { get; set; }
    }
}