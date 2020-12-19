using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace
{
    public class SettingHelper
    {
        public static MvcHtmlString GetSettingItem(string SName)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();

            string SettingName;
            try
            {
                SettingName = db.Database.SqlQuery<string>("select top 1 [SettingValue] from [dbo].[AspSysSetting] where [SettingName] = '" + SName + "'").Single();
            }
            catch (Exception ex)
            {
                SettingName = "";
            }
            string gadgetItem;

            gadgetItem = SettingName;

            return new MvcHtmlString(gadgetItem);
            // return menuList;
        }
    }
}