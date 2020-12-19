using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MangroveSpace;
using MapProject;
using Microsoft.AspNet.Identity;

namespace MapProject.Controllers
{
    public class LocationController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        // GET: Location
        public ActionResult Index()
        {
            var PowerPlant_Main = db.PowerPlant_Main.Include(l => l.PowerPlant_Category);
            return View(PowerPlant_Main.ToList());
        }

        public ActionResult UpdateDetailsPage(string pagetitle)
        {
            try
            {
                if (pagetitle == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSPage aspCMSPage = db.AspCMSPages.Where(s => s.PageID == pagetitle).FirstOrDefault();
                if (aspCMSPage == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(aspCMSPage);
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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateDetailsPage(AspCMSPage AspCMSPage)
        {
            db.Entry(AspCMSPage).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateDetailsPageCode(string pagetitle)
        {
            try
            {
                if (pagetitle == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSPage aspCMSPage = db.AspCMSPages.Where(s => s.PageID == pagetitle).FirstOrDefault();
                if (aspCMSPage == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(aspCMSPage);
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

        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PowerPlant_Main PowerPlant_Main = db.PowerPlant_Main.Find(id);
                AspCMSPage aspCMSPage = db.AspCMSPages.Where(s => s.PageID == PowerPlant_Main.DetailsPageAddress).FirstOrDefault();

                if (PowerPlant_Main == null)
                {
                    return HttpNotFound();
                }
                db.AspCMSPages.Remove(aspCMSPage);
                db.PowerPlant_Main.Remove(PowerPlant_Main);
                db.SaveChanges();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
