using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserRolesController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();
        // GET: UserRoles
        public ActionResult Index()
        {
            try
            {
                IEnumerable<dynamic> userRoles = Global.Sql(db, "SELECT u.[UserName], u.[Email], r.[Name] AS Role, [UserId] AS MapUID, [RoleId] AS MapRID FROM [dbo].[AspNetUsers] u " +
                "INNER JOIN[dbo].[AspNetUserRoles] ur ON u.[Id] = ur.[UserId] "+
                "INNER JOIN[dbo].[AspNetRoles] r ON ur.[RoleId] = r.[Id]").ToList();

                return View(userRoles);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult Create()
        {
            var users = Global.Sql(db, "SELECT [Id], [Email] FROM [dbo].[AspNetUsers]");
            ViewBag.Users = users;
            var roles = Global.Sql(db, "SELECT [Id], [Name] FROM [dbo].[AspNetRoles]");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string UserID, string RoleID)
        {
            if (!String.IsNullOrEmpty(UserID) && !String.IsNullOrEmpty(RoleID))
            {
                string exists = Global.exec("SELECT [RoleId] FROM [dbo].[AspNetUserRoles] WHERE UserId = '" + UserID + "'");
                if (String.IsNullOrEmpty(exists) || exists == "")
                {
                    db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspNetUserRoles](UserId, RoleId) VALUES('" + UserID + "','" + RoleID + "')");
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Msg = "User has Existing Role. Please Remove Exiting to Assign New One ";
                }
            }

            var users = Global.Sql(db, "SELECT [Id], [Email] FROM [dbo].[AspNetUsers]");
            ViewBag.Users = users;
            var roles = Global.Sql(db, "SELECT [Id], [Name] FROM [dbo].[AspNetRoles]");
            ViewBag.Roles = roles;
            return View();
        }

        public ActionResult Delete(string userid, string roleid)
        {
            try
            {
                if (String.IsNullOrEmpty(userid) && String.IsNullOrEmpty(roleid))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[AspNetUserRoles] WHERE [UserId]='"+ userid + "' AND [RoleId] = '"+ roleid + "';");

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
    }
}