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
    
    public partial class AspCMSTableContent
    {
        public int ID { get; set; }
        public string TableID { get; set; }
        public Nullable<System.DateTime> TableDate { get; set; }
        public string TableTitle { get; set; }
        public string TableShortDesc { get; set; }
        public string TableDesc { get; set; }
        public string TableFile { get; set; }
        public string TableFileAttach { get; set; }
        public string TableThumb { get; set; }
        public Nullable<int> TableOrder { get; set; }
        public string TableJSONContent { get; set; }
        public Nullable<bool> TableContentStatus { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<int> AccessID { get; set; }
    }
}