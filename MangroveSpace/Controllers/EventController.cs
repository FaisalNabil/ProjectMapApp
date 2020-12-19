using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class EventController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();
        // GET: Event
        [Authorize]
        [HttpGet]
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // Index
        public ActionResult Index()
        {
            try
            {
            List<dynamic> aspCMSEvent = Global.Sql(db, "SELECT *FROM [dbo].[AspCMSEvent] WHERE [EventCategory]='1' ORDER BY [EventOrderID] DESC").ToList();
            return View(aspCMSEvent);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

           
        }

        //get create
        [Authorize]
        [HttpGet]
        public ActionResult Create()
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

        //post create
        [Authorize]
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventName,Time1,Time2,AttachFile,EventDescription,EventStatus,EventDate")] AspCMSEvent aspEvent, HttpPostedFileBase File)
        {

            try
            {
            string AttachFileName = "";
            string AttachFileExt = "";
            string AttachFolderPath = "";

            if (ModelState.IsValid)
            {

                int EventID = db.Database.SqlQuery<Int32>("SELECT ISNULL(MAX(EventID)+1, 1) FROM [AspCMSEvent]").Single();
                int EventOrderID = db.Database.SqlQuery<Int32>("SELECT ISNULL(MAX([EventOrderID])+1,1) FROM [dbo].[AspCMSEvent] WHERE [EventCategory]=1").Single();
                try
                {
                    string[] validateFile = new string[] { "text/plain", "application/pdf", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "image/jpeg", "image/jpg", "image/png", "image/gif", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
                    string Validate = Global.GetMIMEType(File.FileName);
                    if (validateFile.Contains(Validate))
                    {
                        AttachFileName = Path.GetFileNameWithoutExtension(File.FileName);
                        AttachFileExt = Path.GetExtension(File.FileName);
                        AttachFileName = "Ev-" + EventID + AttachFileExt;
                        AttachFolderPath = "/Uploads/EventFile/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("~/Uploads/EventFile/"), AttachFileName);
                        File.SaveAs(AttachFileName);

                    }
                    else
                    {
                        TempData["msgs"] = "Please select (pdf,doc,docx,xlx,png,jpeg,jpg,gif)";
                        return View(aspEvent);
                    }
                }
                catch
                {
                    TempData["msgs"] = "Somthing Went Wrong";
                    AttachFolderPath = "";
                }

                aspEvent.EntryDate = DateTime.Now;
                aspEvent.EventOrderID = EventOrderID;
                aspEvent.EventStatus = true;
                aspEvent.EntryBy = User.Identity.GetUserId();
                aspEvent.EventID = EventID;
                aspEvent.AttachFile = AttachFolderPath;
                aspEvent.EventCategory = Convert.ToString(1);
                db.AspCMSEvents.Add(aspEvent);
                db.SaveChanges();
                TempData["msg"] = "Successfuly Saved";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["msgs"] = "Somthing Went Wrong";
                return View(aspEvent);
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


        //EDIT: Event
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSEvent aspEvent = db.AspCMSEvents.Find(id);
            if (aspEvent == null)
            {
                return HttpNotFound();
            }
            return View(aspEvent);

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
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EventName,Time1,Time2,AttachFilePath,AttachFile,EventDescription,EventStatus,EventDate")] AspCMSEvent aspEvent, HttpPostedFile AttachFilePath)
        {

            try
            {
            string AttachFileName = "";
            string AttachFileExt = "";
            string AttachFolderPath = "";

            if (ModelState.IsValid)
            {
                try
                {
                    string[] validateFile = new string[] { "text/plain", "application/pdf", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "image/jpeg", "image/jpg", "image/png", "image/gif", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
                    //bool bol = Array.Exists(validateFile, E => E == Validate);
                    string Validate = Global.GetMIMEType(AttachFilePath.FileName);
                    if (validateFile.Contains(Validate))
                    {
                        AttachFileName = Path.GetFileNameWithoutExtension(AttachFilePath.FileName);
                        AttachFileExt = Path.GetExtension(AttachFilePath.FileName);
                        AttachFileName = "No" + aspEvent.EventID + AttachFileExt;
                        AttachFolderPath = "/Content/Event/" + AttachFileName;
                        aspEvent.AttachFile = AttachFolderPath;
                        AttachFileName = Path.Combine(Server.MapPath("~/Uploads/EventFile/"), AttachFileName);
                        AttachFilePath.SaveAs(AttachFileName);

                        aspEvent.ModifyDate = DateTime.Now;
                        aspEvent.ModifyBy = User.Identity.GetUserId();
                        db.Entry(aspEvent).State = EntityState.Modified;
                        db.Entry(aspEvent).Property(e => e.EventID).IsModified = false;
                        db.Entry(aspEvent).Property(e => e.EntryBy).IsModified = false;
                        db.Entry(aspEvent).Property(e => e.EntryDate).IsModified = false;
                        db.Entry(aspEvent).Property(e => e.EventCategory).IsModified = false;
                        db.Entry(aspEvent).Property(e => e.EventOrderID).IsModified = false;
                        db.SaveChanges();
                        TempData["msg"] = "Successfuly Updated";
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["msgs"] = "Please select (pdf,doc,docx,xlx,png,jpeg,jpg,gif)";
                        return View(aspEvent);
                    }

                }
                catch
                {
                    AttachFolderPath = "";
                }

                aspEvent.ModifyDate = DateTime.Now;
                aspEvent.ModifyBy = User.Identity.GetUserId();
                db.Entry(aspEvent).State = EntityState.Modified;
                db.Entry(aspEvent).Property(e => e.EventID).IsModified = false;
                db.Entry(aspEvent).Property(e => e.EntryBy).IsModified = false;
                db.Entry(aspEvent).Property(e => e.EntryDate).IsModified = false;
                db.Entry(aspEvent).Property(e => e.EventCategory).IsModified = false;
                db.Entry(aspEvent).Property(e => e.AttachFile).IsModified = false;
                db.Entry(aspEvent).Property(e => e.EventOrderID).IsModified = false;
                db.SaveChanges();
                TempData["msg"] = "Successfuly Updated";
                return RedirectToAction("Index");

            }
            else
            {
                return View(aspEvent);
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



        //EDIT: CodeViewEvent
        [Authorize]
        [HttpGet]
        public ActionResult CodeViewEvent(int? id)
        {

            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSEvent aspEvent = db.AspCMSEvents.Find(id);
            if (aspEvent == null)
            {
                return HttpNotFound();
            }
            return View(aspEvent);

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
        public ActionResult Delete(int? id)
        {

            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSEvent Event = db.AspCMSEvents.Find(id);


            int EventOrderID = Convert.ToInt32(Event.EventOrderID);

            if (Event == null)
            {
                return HttpNotFound();
            }

            string path = Server.MapPath(Event.AttachFile);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            List<dynamic> aspCMSEvent = Global.Sql(db, "SELECT * FROM [AspCMSEvent] WHERE  [EventOrderID] > '" + EventOrderID + "' AND [EventCategory] = '" + 1 + "' ").ToList();

            foreach (dynamic i in aspCMSEvent)
            {
                int newEventOrderID = i.EventOrderID - 1;

                db.Database.ExecuteSqlCommand("UPDATE AspCMSEvent SET EventOrderID = '" + newEventOrderID + "' WHERE [ID] = '" + i.ID + "'");
            }
            db.AspCMSEvents.Remove(Event);
            db.SaveChanges();
            TempData["msg"] = "Successfuly Deleted";
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

        [Authorize]
        [HttpGet]
        public ActionResult StatusInactive(int id)
        {

            try
            {

            AspCMSEvent Event = db.AspCMSEvents.Find(id);
            if (Event == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSEvent] SET [EventStatus] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' WHERE ID = '" + id + "' ");
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


        [Authorize]
        [HttpGet]
        public ActionResult StatusActive(int id)
        {

            try
            {

            AspCMSEvent Event = db.AspCMSEvents.Find(id);
            if (Event == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSEvent] SET [EventStatus] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' WHERE ID = '" + id + "' ");
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


        public ActionResult Increment(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSEvent AspCMSEvent = db.AspCMSEvents.Find(id);
                if (AspCMSEvent == null)
                {
                    return HttpNotFound();
                }

                int MinOrder = Global.execInt("Select min(EventOrderID) From [AspCMSEvent]");

                if (AspCMSEvent.EventOrderID == MinOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int temp1Order = Convert.ToInt32(AspCMSEvent.EventOrderID);
                    int tempOrder = Global.execInt("Select max(EventOrderID) From AspCMSEvent where EventOrderID<'" + AspCMSEvent.EventOrderID + "'");
                    int temp1ID = Convert.ToInt32(AspCMSEvent.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSEvent WHERE EventOrderID='" + tempOrder + "'");



                    db.Database.ExecuteSqlCommand("UPDATE AspCMSEvent SET EventOrderID=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSEvent SET EventOrderID=" + tempOrder + " WHERE ID=" + temp1ID);
                    AspCMSEvent.ModifyBy = User.Identity.GetUserName();
                    AspCMSEvent.ModifyDate = DateTime.Now;
                    db.Entry(AspCMSEvent).State = EntityState.Modified;



                    //db.SaveChanges();
                    return Redirect(Request.UrlReferrer.ToString());

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


        public ActionResult Decrement(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSEvent AspCMSEvent = db.AspCMSEvents.Find(id);
                if (AspCMSEvent == null)
                {
                    return HttpNotFound();
                }


                int MaxOrder = Global.execInt("Select max(EventOrderID) From AspCMSEvent");
                if (AspCMSEvent.EventOrderID == MaxOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int tempOrder = Global.execInt("Select min(EventOrderID) From AspCMSEvent where EventOrderID>'" + AspCMSEvent.EventOrderID + "'");
                    int temp1Order = Convert.ToInt32(AspCMSEvent.EventOrderID);
                    int temp1ID = Convert.ToInt32(AspCMSEvent.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSEvent WHERE EventOrderID='" + tempOrder + "'");

                    db.Database.ExecuteSqlCommand("UPDATE AspCMSEvent SET EventOrderID=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSEvent SET EventOrderID=" + tempOrder + " WHERE ID=" + temp1ID);

                    AspCMSEvent.ModifyBy = User.Identity.GetUserName();
                    AspCMSEvent.ModifyDate = DateTime.Now;
                    db.Entry(AspCMSEvent).State = EntityState.Modified;


                    //db.SaveChanges();
                    return Redirect(Request.UrlReferrer.ToString());

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

        [AllowAnonymous]
        public ActionResult EventDetails(int? id)
        {

            try
            {

               List<dynamic> Information = Global.Sql(db, "select  [ID],[EventID],[EventName],[EventDescription],[EventDate],[Time1],[Time2],[EventCategory],[AttachFile] from [dbo].[AspCMSEvent] where EventID='" + id + "' and  [EventStatus]=1 order by [EventOrderID] ASC").ToList();
               return View(Information);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        [AllowAnonymous]
        public ActionResult AllEvents()
        {

            try
            {
            List<dynamic> Information = Global.Sql(db, "select  [ID],[EventID],[EventName],[EventDescription],[EventDate],[Time1],[Time2],[EventCategory],[AttachFile] from [dbo].[AspCMSEvent] where [EventStatus]=1 order by [EventOrderID] ASC").ToList();
            return View(Information);

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