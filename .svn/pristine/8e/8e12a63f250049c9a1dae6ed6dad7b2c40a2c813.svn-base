using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MangroveSpace.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using MangroveSpace;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class GadgetsController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        // GET: Gadgets
        public ActionResult Index()
        {
            try
            {
                IEnumerable<dynamic> aspCmsGadget = Global.Sql(db, "SELECT [ID],[GadgetID],[GadgetName],[GadgetLanguage] from [dbo].[AspCMSGadget]").ToList();
                return View(aspCmsGadget);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        // GET: Gadgets/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSGadget aspCMSGadget = db.AspCMSGadgets.Find(id);
            if (aspCMSGadget == null)
            {
                return HttpNotFound();
            }
            return View(aspCMSGadget);
        }*/

        // GET: Gadgets/Create
        public ActionResult Create()
        {
            try
            {
                var aspCmsGadget = new AspCMSGadget();
                aspCmsGadget.GadgetID = db.Database.SqlQuery<int>("select dbo.GenCmsGadgetID(2)").Single();


                return View(aspCmsGadget);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }



        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GadgetID,GadgetName,GadgetHTML,GadgetLanguage,ContainID,OrderID,Setting,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSGadget aspCMSGadget)
        {
            try
            {
                string oldGadgetname;
                string newGadgetname = aspCMSGadget.GadgetName;
                if (ModelState.IsValid)
                {
                    oldGadgetname = Global.exec("select GadgetName from [dbo].[AspCMSGadget] Where GadgetName='" + newGadgetname + "'");

                    if (oldGadgetname == newGadgetname)
                    {
                        TempData["msg"] = "Gadget Title Already Exists!";
                        return View(aspCMSGadget);
                    }

                    aspCMSGadget.GadgetLanguage = "English";
                    aspCMSGadget.EntryDate = DateTime.Now;
                    aspCMSGadget.EntryBy = User.Identity.GetUserName();
                    aspCMSGadget.ModifyBy = User.Identity.GetUserName();
                    aspCMSGadget.ModifyDate = DateTime.Now;

                    db.AspCMSGadgets.Add(aspCMSGadget);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(aspCMSGadget);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        // GET: Gadgets/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSGadget aspCMSGadget = db.AspCMSGadgets.Find(id);
                if (aspCMSGadget == null)
                {
                    return HttpNotFound();
                }
                return View(aspCMSGadget);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        // POST: Gadgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GadgetID,GadgetName,GadgetHTML,GadgetLanguage,ContainID,OrderID,Setting,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSGadget aspCMSGadget)
        {
            try
            {
                string oldGadgetname;
                string newGadgetname = aspCMSGadget.GadgetName;
                if (ModelState.IsValid)
                {
                    

                   


                    aspCMSGadget.ModifyBy = User.Identity.GetUserName();
                    aspCMSGadget.ModifyDate = DateTime.Now;
                    db.Entry(aspCMSGadget).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(aspCMSGadget);
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
                AspCMSGadget aspCMSGadget = db.AspCMSGadgets.Find(id);
                if (aspCMSGadget == null)
                {
                    return HttpNotFound();
                }
                db.AspCMSGadgets.Remove(aspCMSGadget);
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



        // GET: CodeViewGadget
        public ActionResult CodeViewGadget(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSGadget aspCMSGadget = db.AspCMSGadgets.Find(id);
                if (aspCMSGadget == null)
                {
                    return HttpNotFound();
                }
                return View(aspCMSGadget);
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

