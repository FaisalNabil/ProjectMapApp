using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MangroveSpace
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(AspCMSNoticeMetaData))]
    public partial class AspCMSNotice
    {


    }
    public partial class AspCMSNoticeMetaData
    {
        public int ID { get; set; }
        public Nullable<int> NoticeID { get; set; }
        [Required]
        [Display(Name = "Notice Name")]
        public string NoticeName { get; set; }
        public string NoticeDescription { get; set; }
        [Required]
        [Display(Name = "Notice Date")]
        public Nullable<System.DateTime> NoticeDate { get; set; }
        public string NoticeCategory { get; set; }
        public string AttachFile { get; set; }
        public Nullable<int> NoticeOrderID { get; set; }
        public Nullable<bool> NoticeStatus { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public Nullable<int> NoticePrivilege { get; set; }
        public string NoticePrivilegeOption { get; set; }
        public Nullable<bool> Aproved { get; set; }
        public string AprovedBy { get; set; }
        public string NoticeLogic { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
