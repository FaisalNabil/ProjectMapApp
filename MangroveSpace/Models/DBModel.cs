using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangroveSpace.Models
{

        public class SysMenu
        {
            public int ID { get; set; }
            public string MenuParentID { get; set; }
            public string MenuDisplayName { get; set; }
            public string MenuIcon { get; set; }
            public string MenuLink { get; set; }
            public int MenuOrder { get; set; }
        }
        public class MenuViewModel
        {
            public int ID { get; set; }
            public string MenuDisplayName { get; set; }
            public string MenuIcon { get; set; }
            public string MenuLink { get; set; }
            public IList<MenuViewModel> Children { get; set; }
        }

        public class images
        {

            public string name { get; set; }
            public string path { get; set; }
            public long size { get; set; }
        }

}