using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MangroveSpace
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [MetadataType(typeof(AspCMSAlbumDetailMetaData))]
    public partial class AspCMSAlbumDetail
    {


    }
    public partial class AspCMSAlbumDetailMetaData
    {
        public int ID { get; set; }
        [Display(Name ="Album Details ID")]
        public string ADID { get; set; }
        public string AID { get; set; }
        [Display(Name = "Album Details Title")]
        public string AlbumDetailsTitle { get; set; }
        [Display(Name = "Album Details Description")]
        public string AlbumDetailsDescription { get; set; }
        [Display(Name = "Album Details Order")]
        public Nullable<int> AlbumDetailsOrder { get; set; }
        [Display(Name ="Image")]
        public string AlbumDetailImagePath { get; set; }
       
        [Display(Name ="Status")]
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
