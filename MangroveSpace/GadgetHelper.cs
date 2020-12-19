using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace
{
    public static class GadgetHelper
    {
        public static MvcHtmlString GetGadgetItem(this HtmlHelper helper, string name)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();

            string GadgetName;
            try
            {
                GadgetName = db.Database.SqlQuery<string>("select [GadgetHTML] from [AspCMSGadget] Where GadgetName='" + name + "'").Single();
            }
            catch (Exception ex)
            {
                GadgetName = "<p>" + ex.Message + "</p>";
            }
            string gadgetItem;

            gadgetItem = GadgetName;

            return new MvcHtmlString(gadgetItem);
            // return menuList;
        }
    }
}