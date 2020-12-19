using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MangroveSpace
{
    using System;
    using System.Collections.Generic;
    
    using System.Web.Mvc;

    [MetadataType(typeof(AspCMSAlbumMetaData))]
    public partial class AspCMSAlbum
    {


    }
    public partial class AspCMSAlbumMetaData
    {
        public int ID { get; set; }
        [Display(Name ="Album ID")]
        
        public string AID { get; set; }
        [Required]
        [Display(Name ="Date")]
        public Nullable<System.DateTime> CDate { get; set; }
        [Required]
        [Display(Name ="Album Title")]
        public string AlbumTitle { get; set; }
        [AllowHtml]
        [Display(Name ="Album Description")]
        public string AlbumDescription { get; set; }
        public string AlbumDefault { get; set; }
        [Display(Name ="Album Order")]
        public Nullable<int> AlbumOrder { get; set; }
      
        [Display(Name ="Album Status")]
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string AlbumImage { get; set; }
    }
}
