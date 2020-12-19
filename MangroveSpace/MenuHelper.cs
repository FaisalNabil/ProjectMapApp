using MangroveSpace;
using Microsoft.AspNet.Identity;
using MangroveSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace MangroveSpace
{
    public class MenuHelper
    {
        public static IList<SysMenu> GetAllMenuItems(string MenuType)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            return db.Database.SqlQuery<SysMenu>("select * from [dbo].[AspCMSMenu] where [MenuType] = '"  + MenuType + "' order by [MenuOrder]").ToList();
        }

        public static IList<SysMenu> GetAllSysMenuItems(string MenuType)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            string userRole = HttpContext.Current.Session["UserRole"].ToString();
            return db.Database.SqlQuery<SysMenu>("select * from [dbo].[AspSysMenu] where [MenuType] = '" + MenuType + "' AND [RoleID] = '" + userRole + "' order by [MenuOrder]").ToList();
        }
        public static IList<SysMenu> GetAllSysMenuItemsForEdit(string MenuType)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            string userRole = HttpContext.Current.Session["UserRole"].ToString();
            if (HttpContext.Current.Session["RoleId"] != null)
            {
                userRole = HttpContext.Current.Session["RoleId"].ToString(); 
            }
            return db.Database.SqlQuery<SysMenu>("select * from [dbo].[AspSysMenu] where [MenuType] = '" + MenuType + "' AND [RoleID] = '" + userRole + "' order by [MenuOrder]").ToList();
        }

        public static IList<SysMenu> GetChildrenMenu(IList<SysMenu> menuList, string parentId = null)
        {
            return menuList.Where(x => x.MenuParentID == parentId).OrderBy(x => x.MenuOrder).ToList();
        }

        public static IList<SysMenu> GetSysChildrenMenu(IList<SysMenu> menuList, string parentId)
        {
            return menuList.Where(x => x.MenuParentID == parentId).OrderBy(x => x.MenuOrder).ToList();
        }

        public static SysMenu GAspCMSMenusetMenuItem(IList<SysMenu> menuList, int id)
        {
            return menuList.FirstOrDefault(x => x.ID == id);
        }
    }
}