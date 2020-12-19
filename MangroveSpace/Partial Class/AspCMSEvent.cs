using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangroveSpace
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(AspCMSEventMetaData))]
    public partial class AspCMSEvent
    {


    }
    public partial class AspCMSEventMetaData
    {
        public int ID { get; set; }
        public Nullable<int> EventID { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        [Required]
        [Display(Name = "Event Date")]
        public Nullable<System.DateTime> EventDate { get; set; }
        public string EventCategory { get; set; }
        public string AttachFile { get; set; }
        public Nullable<int> EventOrderID { get; set; }
        public Nullable<bool> EventStatus { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public Nullable<int> EventPrivilege { get; set; }
        public string EventPrivilegeOption { get; set; }
        public Nullable<bool> Aproved { get; set; }
        public string AprovedBy { get; set; }
        public string EventLogic { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}