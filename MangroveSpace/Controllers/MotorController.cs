using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace.Controllers
{
    public class MotorController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        // GET: Motor
        public ActionResult Index()
        {
            var PowerPlant_Child = db.PowerPlant_Child.ToList();
            return View(PowerPlant_Child);
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
        public ActionResult UpdateDetailsPage(PowerPlant_Child PowerPlant_Child)
        {
            db.Entry(PowerPlant_Child).State = EntityState.Modified;
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
                PowerPlant_Child PowerPlant_Child = db.PowerPlant_Child.Find(id);
                AspCMSPage aspCMSPage = db.AspCMSPages.Where(s => s.PageID == PowerPlant_Child.DetailsPageAddress).FirstOrDefault();

                if (PowerPlant_Child == null)
                {
                    return HttpNotFound();
                }
                db.AspCMSPages.Remove(aspCMSPage);
                db.PowerPlant_Child.Remove(PowerPlant_Child);
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