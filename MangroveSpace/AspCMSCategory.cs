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
    
    public partial class AspCMSCategory
    {
        public int ID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategorySubName { get; set; }
        public string CategoryContentType { get; set; }
        public Nullable<bool> CategoryStatus { get; set; }
        public string CategoryLogic { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}