using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangroveSpace
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(AspCMSPageMetaData))]
    public partial class AspCMSPage
    {


    }
    public partial class AspCMSPageMetaData
    {
        public int ID { get; set; }
        public string PageID { get; set; }
        [Required]
        [Display(Name = "Page Title")]
        public string PageTitle { get; set; }
        [Display(Name = "Page Body")]
        public string PageBody { get; set; }
        public string PageTamplateID { get; set; }
        public string PageType { get; set; }
        public string PageLanguage { get; set; }
        public Nullable<bool> Aproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string TAG { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
