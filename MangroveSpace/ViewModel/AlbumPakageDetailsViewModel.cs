using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangroveSpace.ViewModel
{
    public class AlbumPakageDetailsViewModel
    {
        public AspCMSAlbumDetail AspCMSAlbumDetail { get; set; }
        public IEnumerable<dynamic> AspCMSAlbum { get; set; }
        
    }
}