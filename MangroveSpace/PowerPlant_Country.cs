//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MangroveSpace
{
    using System;
    using System.Collections.Generic;
    
    public partial class PowerPlant_Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PowerPlant_Country()
        {
            this.PowerPlant_General = new HashSet<PowerPlant_General>();
            this.PowerPlant_Technical = new HashSet<PowerPlant_Technical>();
            this.PowerPlant_Main = new HashSet<PowerPlant_Main>();
        }
    
        public int ID { get; set; }
        public string Country_Name { get; set; }
        public string TwoCharCountryCode { get; set; }
        public string ThreeCharCountryCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PowerPlant_General> PowerPlant_General { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PowerPlant_Technical> PowerPlant_Technical { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PowerPlant_Main> PowerPlant_Main { get; set; }
    }
}
