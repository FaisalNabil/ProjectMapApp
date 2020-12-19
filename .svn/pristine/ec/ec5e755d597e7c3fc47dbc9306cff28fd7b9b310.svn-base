using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MangroveSpace
{
    using System;
    using System.Collections.Generic;
    [MetadataType(typeof(AspCMSGadgetMetaData))]
    public partial class AspCMSGadget
    {


    }
    public partial class AspCMSGadgetMetaData
    {
        public int ID { get; set; }
        [Display(Name = "Gadget ID")]
        public Nullable<int> GadgetID { get; set; }
        [Required]
        [Display(Name = "Gadget Name")]
        public string GadgetName { get; set; }
        [Display(Name = "Gadget Html")]
        public string GadgetHTML { get; set; }
        [Display(Name = "Gadget Language")]
        public string GadgetLanguage { get; set; }
        public string ContainID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public string Setting { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }

        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
