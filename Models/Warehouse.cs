//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eProject3_Verhicle_Management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ShowroomId { get; set; }
        public Nullable<int> Quantily { get; set; }
    
        public virtual Showroom Showroom { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
