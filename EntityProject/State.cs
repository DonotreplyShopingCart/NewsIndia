//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public Nullable<int> CountryId { get; set; }
    
        public virtual Country Country { get; set; }
    }
}
