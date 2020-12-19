using MangroveSpace.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SysMenuController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: SysMenu
        public ActionResult Index()
        {
            ModelState.Clear();
            try
            {
                List<dynamic> Role = Global.Sql(db, "select [Id], [Name] from[dbo].[AspNetRoles]").ToList();
                ViewBag.Role = Role;

                string roleId = string.Empty;

                if (Session["RoleId"] == null)
                {
                    roleId = Role.First().Id;
                    //roleId = "SendSmsRollID";
                    Session["RoleId"] = roleId;
                }
                else
                {
                    roleId = Session["RoleId"].ToString();
                }

                ViewBag.SelectedRole = roleId;

                //List<dynamic> Information = Global.Sql(db, "select [ID],[MenuID],[MenuParentID],[MenuType],[MenuName],[MenuDisplayName],[MenuLanguage]"+
                //                                          ",[MenuLink],[MenuLinkOption],[MenuOrder],[MenuStatus],[MenuSerial],[MenuPrivilege],[MenuPrivilegeOption],[MenuIcon],[MenuContent]"+
                //                                          ",[MenuSlug],[MenuTitle],[EntryDate],[EntryBy],[ModifyDate],[ModifyBy],[AccessID],[RoleID] from [dbo].[AspSysMenu]" +
                //                                          "WHERE [RoleID] ='"+ roleId + "'").ToList();
                return View(/*Information*/);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        

        [Authorize]
        public ActionResult Create()
        {
            try
            {
                List<dynamic> ParentMenu = Global.Sql(db, "select [MenuID], [MenuDisplayName] from[dbo].[AspSysMenu]").ToList();
                ViewBag.ParentMenu = ParentMenu;

                List<dynamic> Role = Global.Sql(db, "select [Id], [Name] from[dbo].[AspNetRoles]").ToList();
                ViewBag.Role = Role;
                return View();
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }


        //Menu Design
        public ActionResult MenuDesign()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }


        }


        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Include = "MenuName,MenuDisplayName,MenuTitle,MenuLink,MenuIcon")] AspSysMenu menu, string MenuParentID, string MenuRoleID)
        {
            try
            {
            string NewMenuSlug;
            string MenuSlug;
            string MenuID = Global.exec("SELECT cast(isnull(MAX([MenuID])+1,1) as varchar(10)) as [MenuID] FROM [dbo].[AspSysMenu]");
            int MenuOrder = Global.exec("SELECT isnull(MAX([MenuOrder])+1,1) as [MenuOrder] FROM [dbo].[AspSysMenu]", 1);
            
            if (ModelState.IsValid)
            {
                NewMenuSlug = menu.MenuTitle.Trim();
                NewMenuSlug = NewMenuSlug.Replace(" ", "-");
                MenuSlug = Global.exec("select [MenuSlug] from [dbo].[AspSysMenu] where [MenuSlug]='" + NewMenuSlug + "'");
                if (NewMenuSlug == MenuSlug)
                {
                    TempData["msgSlag"] = "Menu Title Already Exists!";
                    return View(menu);
                }
                menu.MenuSerial = 0;
                if(MenuParentID == "Select a Menu")
                {
                    menu.MenuParentID = null;
                }
                else
                {
                    menu.MenuParentID = MenuParentID;
                }

                if (MenuRoleID == "Select a Role")
                {
                    menu.RoleID = null;
                }
                else
                {
                    menu.RoleID = MenuRoleID;
                }

                    menu.MenuStatus = true;
                menu.MenuID = MenuID;
                menu.MenuOrder = MenuOrder;
                menu.MenuSlug = NewMenuSlug;
                //menu.MenuLink = "/Pages/Page?pid=" + menu.MenuLink;
                menu.EntryBy = User.Identity.GetUserName();
                menu.MenuLanguage = "EN";
                menu.MenuType = "Top Menu";
                menu.EntryDate = DateTime.Now;
                db.AspSysMenus.Add(menu);
                db.SaveChanges();
                TempData["msg"] = "Data Successfuly Saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(menu);
            }

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }


        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                List<dynamic> ParentMenu = Global.Sql(db, "select [ID], [MenuDisplayName] from[dbo].[AspSysMenu]").ToList();
                ViewBag.ParentMenu = ParentMenu;

                List<dynamic> Role = Global.Sql(db, "select [Id], [Name] from[dbo].[AspNetRoles]").ToList();
                ViewBag.Role = Role;
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspSysMenu MenuInfo = db.AspSysMenus.Find(id);
                if (MenuInfo == null)
                {
                    return HttpNotFound();
                }
                return View(MenuInfo);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }



        [Authorize]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,MenuID,MenuParentID,MenuType,MenuLinkOption,MenuName,MenuDisplayName,MenuTitle,MenuLink,MenuIcon,MenuLanguage,MenuOrder,MenuStatus,MenuSerial,MenuPrivilege,MenuPrivilegeOption,MenuContent,MenuSlug")] AspSysMenu menu, string MenuParentID, string MenuRoleID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menu.MenuSerial = 0;
                    if (MenuParentID == "Select a Menu")
                    {
                        menu.MenuParentID = null;
                    }
                    else
                    {
                        menu.MenuParentID = MenuParentID;
                    }

                    if (MenuRoleID == "Select a Role")
                    {
                        menu.RoleID = null;
                    }
                    else
                    {
                        menu.RoleID = MenuRoleID;
                    }
                    menu.ModifyBy = User.Identity.GetUserId();
                    menu.ModifyDate = DateTime.Now;
                    db.Entry(menu).State = EntityState.Modified;
                    //db.Entry(menu).Property(e => e.MenuParentID).IsModified = false;
                    db.Entry(menu).Property(e => e.EntryBy).IsModified = false;
                    db.Entry(menu).Property(e => e.EntryDate).IsModified = false;
                    //db.Entry(menu).Property(e => e.MenuID).IsModified = false;
                    //db.Entry(menu).Property(e => e.MenuStatus).IsModified = false;
                    //db.Entry(menu).Property(e => e.MenuOrder).IsModified = false;
                    db.SaveChanges();
                    TempData["msg"] = "Data Successfuly Updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(menu);
                }

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }


        [Authorize]
        public ActionResult Delete(int id)
        {

            try
            {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspSysMenu Menu = db.AspSysMenus.Find(id);
            if (Menu == null)
            {
                return HttpNotFound();
            }
            else
            {

                db.AspSysMenus.Remove(Menu);
                db.SaveChanges();
                TempData["msgs"] = "Data Successfuly Deleted";
                return RedirectToAction("Index");
            }

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }


        }


        //GET: Menu/StatusInactive/id
        [Authorize]
        [HttpGet]
        public ActionResult StatusInactive(int id)
        {
            try
            {
            AspSysMenu Menu = db.AspSysMenus.Find(id);
            if (Menu == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspSysMenu] SET [MenuStatus] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
            TempData["msg"] = "Successfuly Inactivated";
            return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }


        //GET: Menu/StatusActive/id
        [Authorize]
        [HttpGet]
        public ActionResult StatusActive(int id)
        {
            try
            {
            AspSysMenu Menu = db.AspSysMenus.Find(id);
            if (Menu == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspSysMenu] SET [MenuStatus] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
            TempData["msg"] = "Successfuly Inactivated";
            return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        // GET: Menu
        [Authorize]
        public ActionResult Ordering()
        {
            try
            {
            this.Session["SelectMenu"] = "Top Menu";
            //var ordering = db.Database.SqlQuery<AspSysMenu>("select * from [dbo].[AspSysMenu] where [MenuType] = '" + this.Session["SelectMenu"] + "'").ToList();
            return View();

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult Ordering(string MenuType)
        {
            try
            {
            this.Session["SelectMenu"] = MenuType;
            //var ordering = db.Database.SqlQuery<AspSysMenu>("select * from [dbo].[AspSysMenu] where [MenuType] = '" + this.Session["SelectMenu"] + "'").ToList();
            return View();

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        // GET: ProductInformation/Create
        [Authorize]
        [HttpPost]
        public ActionResult OrderingSave(string ioutput)
        {
            try
            {
            string MenuString;
            MenuString = ioutput;


            int ID = 0;
            int ID1 = 0;
            int count = 0;

            List<Item> answer = JsonConvert.DeserializeObject<List<Item>>(MenuString);

            foreach (Item item in answer)
            {
                count++;
                ID = item.Id;

                db.Database.ExecuteSqlCommand("update [dbo].[AspSysMenu] Set [MenuOrder] = " + Convert.ToString(count) + " where [ID] = '" + Convert.ToString(ID) + "'");
                db.Database.ExecuteSqlCommand("update [dbo].[AspSysMenu] Set [MenuParentID] = null where [ID] = '" + Convert.ToString(ID) + "'");


                if (item.Children != null)
                {
                    foreach (Item child in item.Children)
                    {
                        count++;
                        db.Database.ExecuteSqlCommand("update [dbo].[AspSysMenu] Set [MenuOrder] = " + Convert.ToString(count) + " where [ID] = '" + Convert.ToString(child.Id) + "'");
                        db.Database.ExecuteSqlCommand("update [dbo].[AspSysMenu] Set [MenuParentID]= " + Convert.ToString(ID) + " where [ID] = '" + Convert.ToString(child.Id) + "'");

                        ID1 = child.Id;

                        if (child.Children != null)
                        {
                            foreach (Item child1 in child.Children)
                            {
                                count++;
                                db.Database.ExecuteSqlCommand("update [dbo].[AspSysMenu] Set [MenuOrder] = " + Convert.ToString(count) + " where [ID] = '" + Convert.ToString(child1.Id) + "'");
                                db.Database.ExecuteSqlCommand("update [dbo].[AspSysMenu] Set [MenuParentID]= " + Convert.ToString(ID1) + " where [ID] = '" + Convert.ToString(child1.Id) + "'");
                            }
                        }
                    }
                }
            }

            return RedirectToAction("MenuDesign");

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }


        [Authorize]
        [HttpGet]
        public ActionResult SysMenu(int id)
        {
            try
            {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspSysMenu MenuInfo = db.AspSysMenus.Find(id);
            if (MenuInfo == null)
            {
                return HttpNotFound();
            }
            //return View(MenuInfo);
            return PartialView(MenuInfo);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }



        }

        //GET: Menu/Create
        [Authorize]
        [HttpPost]
        public ActionResult SysMenu(AspSysMenu menu)
        {
            try
            {

            string NewMenuSlug;
            string MenuSlug;

            NewMenuSlug = menu.MenuTitle.Trim();
            NewMenuSlug = NewMenuSlug.Replace(" ", "-");
            MenuSlug = Global.exec("select [MenuSlug] from [dbo].[AspSysMenu] where [MenuSlug]='" + NewMenuSlug + "' and [ID]!=" + menu.ID + "");
            if (ModelState.IsValid)
            {

                if (NewMenuSlug == MenuSlug)
                {
                    TempData["msgSlag"] = "Menu Title Already Exists!";
                    return View(menu);
                }
                menu.MenuSerial = 0;
                menu.MenuParentID = "0";
                menu.MenuSlug = NewMenuSlug;
                menu.ModifyBy = User.Identity.GetUserId();
                menu.ModifyDate = DateTime.Now;
                db.Entry(menu).State = EntityState.Modified;
                db.Entry(menu).Property(e => e.MenuParentID).IsModified = false;
                db.Entry(menu).Property(e => e.EntryBy).IsModified = false;
                db.Entry(menu).Property(e => e.EntryDate).IsModified = false;
                db.Entry(menu).Property(e => e.MenuID).IsModified = false;
                db.Entry(menu).Property(e => e.MenuStatus).IsModified = false;
                db.Entry(menu).Property(e => e.MenuOrder).IsModified = false;
                db.SaveChanges();
                TempData["msg"] = "Data Successfuly Updated";
                return RedirectToAction("Ordering");
            }
            else
            {
                return View(menu);
            }

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }


        }

        [HttpPost]
        public void SetRole(string roleId)
         {
            Session["RoleId"] = roleId;

            //return RedirectToAction("Index");
        }

        public JsonResult GetSysParentMenu(string selectedId)
        {
            List<dynamic> ParentMenu = Global.Sql(db, "select [ID], [MenuDisplayName] from[dbo].[AspSysMenu] WHERE [RoleID] ='" + selectedId + "'").ToList();

            return Json(ParentMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int CopySysMenu(string roleId, string copyRoleId)
        {
            string sql = "INSERT INTO [dbo].[AspSysMenu]\n"
           + "([MenuID], \n"
           + " [MenuType], \n"
           + " [MenuName], \n"
           + " [MenuDisplayName], \n"
           + " [MenuLanguage], \n"
           + " [MenuLink], \n"
           + " [MenuLinkOption], \n"
           + " [MenuOrder], \n"
           + " [MenuStatus], \n"
           + " [MenuSerial], \n"
           + " [MenuPrivilege], \n"
           + " [MenuPrivilegeOption], \n"
           + " [MenuIcon], \n"
           + " [MenuContent], \n"
           + " [MenuSlug], \n"
           + " [MenuTitle], \n"
           + " [EntryDate], \n"
           + " [EntryBy], \n"
           + " [ModifyDate], \n"
           + " [ModifyBy], \n"
           + " [AccessID], \n"
           + " [RoleID]\n"
           + ")\n"
           + "       SELECT CAST(\n"
           + "       (\n"
           + "           SELECT MAX(CAST(ISNULL([MenuID], 0) AS INT))\n"
           + "           FROM [dbo].[AspSysMenu]\n"
           + "       ) + ROW_NUMBER() OVER(\n"
           + "       ORDER BY [AspSysMenu].[ID]) AS VARCHAR(50)), \n"
           + "              [MenuType], \n"
           + "              [MenuName], \n"
           + "              [MenuDisplayName], \n"
           + "              [MenuLanguage], \n"
           + "              [MenuLink], \n"
           + "              [MenuLinkOption], \n"
           + "              [MenuOrder], \n"
           + "              [MenuStatus], \n"
           + "              [MenuSerial], \n"
           + "              [MenuPrivilege], \n"
           + "              [MenuPrivilegeOption], \n"
           + "              [MenuIcon], \n"
           + "              [MenuContent], \n"
           + "              [MenuSlug], \n"
           + "              [MenuTitle], \n"
           + "              [EntryDate], \n"
           + "              [EntryBy], \n"
           + "              [ModifyDate], \n"
           + "              [ModifyBy], \n"
           + "              [AccessID], \n"
           + "              '"+ copyRoleId + "'\n"
           + "       FROM [dbo].[AspSysMenu]\n"
           + "       WHERE [RoleID] = '"+roleId+"';";

            int i = db.Database.ExecuteSqlCommand(sql);

            return i;
        }
    }
}