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
    
    public partial class VehicleType
    {
        public VehicleType()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public int Id { get; set; }
        public string VehicleType1 { get; set; }
    
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
