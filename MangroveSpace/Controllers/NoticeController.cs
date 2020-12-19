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
    [Authorize(Roles = "CmsNotice,SuperAdmin,admin")]
    public class NoticeController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Notice
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
            List<dynamic> Information = Global.Sql(db, "select * from [dbo].[AspCMSNotice] where [NoticeCategory]='1' and [NoticeStatus]=1 order by [NoticeID] DESC").ToList();
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

        [Authorize]
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoticeName,AttachFile,NoticeDescription,NoticeStatus,NoticeDate")] AspCMSNotice notice, HttpPostedFileBase AttFile)
        {
            try
            {
            string AttachFileName = "";
            string AttachFileExt = "";
            string AttachFolderPath = "";

            if (ModelState.IsValid)
            {

                int NoticeID = db.Database.SqlQuery<Int32>("select isnull(max([NoticeID])+1,1) from [AspCMSNotice]").Single();
                int NoticeOrderID = db.Database.SqlQuery<Int32>("select isnull(max([NoticeOrderID])+1,1) from [dbo].[AspCMSNotice] where [NoticeCategory]=1").Single();
                try
                {
                    string[] validateFile = new string[] { "text/plain", "application/pdf", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "image/jpeg", "image/jpg", "image/png", "image/gif", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
                    //bool bol = Array.Exists(validateFile, E => E == Validate);
                    string Validate = Global.GetMIMEType(AttFile.FileName);
                    if (validateFile.Contains(Validate))
                    {
                        AttachFileName = Path.GetFileNameWithoutExtension(AttFile.FileName);
                        AttachFileExt = Path.GetExtension(AttFile.FileName);
                        AttachFileName = "No-" + NoticeID + AttachFileExt;
                        AttachFolderPath = "/Uploads/NoticeFile/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("~/Uploads/NoticeFile/"), AttachFileName);
                        AttFile.SaveAs(AttachFileName);
                        notice.AttachFile = AttachFolderPath;

                    }
                    else
                    {
                        TempData["msgs"] = "Please select (pdf,doc,docx,xlx,png,jpeg,jpg,gif)";
                        return View(notice);
                    }

                }
                catch
                {
                    TempData["msgs"] = "Somthing Went Wrong";
                    AttachFolderPath = "";
                }

                notice.EntryDate = DateTime.Now;
                notice.NoticeOrderID = NoticeOrderID;
                notice.EntryBy = User.Identity.GetUserId();
                notice.NoticeID = NoticeID;
                notice.AttachFile = AttachFolderPath;
                notice.NoticeCategory = Convert.ToString(1);
                db.AspCMSNotices.Add(notice);
                db.SaveChanges();
                TempData["msg"] = "Successfuly Saved";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["msgs"] = "Somthing Went Wrong";
                return View(notice);

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
        public ActionResult Edit(int? id)
        {
            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSNotice Notice = db.AspCMSNotices.Find(id);
            if (Notice == null)
            {
                return HttpNotFound();
            }
            return View(Notice);

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
        public ActionResult Edit([Bind(Include = "ID,NoticeName,AttachFilePath,NoticeDescription,NoticeStatus,NoticeDate")] AspCMSNotice notice, HttpPostedFileBase AttachFilePath)
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
                        AttachFileName = "No" + notice.NoticeID + AttachFileExt;
                        AttachFolderPath = "/Uploads/NoticeFile/" + AttachFileName;
                        notice.AttachFile = AttachFolderPath;
                        AttachFileName = Path.Combine(Server.MapPath("~/Uploads/NoticeFile/"), AttachFileName);
                        AttachFilePath.SaveAs(AttachFileName);
                        

                        notice.ModifyDate = DateTime.Now;
                        notice.ModifyBy = User.Identity.GetUserId();
                        db.Entry(notice).State = EntityState.Modified;
                        db.Entry(notice).Property(e => e.NoticeID).IsModified = false;
                        db.Entry(notice).Property(e => e.EntryBy).IsModified = false;
                        db.Entry(notice).Property(e => e.EntryDate).IsModified = false;
                        db.Entry(notice).Property(e => e.NoticeCategory).IsModified = false;
                        db.Entry(notice).Property(e => e.NoticeOrderID).IsModified = false;
                        db.SaveChanges();
                        TempData["msg"] = "Successfuly Updated";
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["msgs"] = "Please select (pdf,doc,docx,xlx,png,jpeg,jpg,gif)";
                        return View(notice);
                    }

                }
                catch
                {

                    AttachFolderPath = "";
                }

                notice.ModifyDate = DateTime.Now;
                notice.ModifyBy = User.Identity.GetUserId();
                db.Entry(notice).State = EntityState.Modified;
                db.Entry(notice).Property(e => e.NoticeID).IsModified = false;
                db.Entry(notice).Property(e => e.EntryBy).IsModified = false;
                db.Entry(notice).Property(e => e.EntryDate).IsModified = false;
                db.Entry(notice).Property(e => e.NoticeCategory).IsModified = false;
                db.Entry(notice).Property(e => e.AttachFile).IsModified = false;
                db.Entry(notice).Property(e => e.NoticeOrderID).IsModified = false;
                db.SaveChanges();
                TempData["msg"] = "Successfuly Updated";
                return RedirectToAction("Index");

            }
            else
            {
                return View(notice);

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



        //CodeView Edit
        [Authorize]
        [HttpGet]
        public ActionResult CodeViewEdit(int? id)
        {
            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSNotice Notice = db.AspCMSNotices.Find(id);
            if (Notice == null)
            {
                return HttpNotFound();
            }
            return View(Notice);

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
        public ActionResult Delete(int ID)
        {
            try
            {
            if (ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSNotice Notice = db.AspCMSNotices.Find(ID);
            if (Notice == null)
            {
                return HttpNotFound();
            }
            else
            {

                db.AspCMSNotices.Remove(Notice);
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


        [Authorize]
        [HttpGet]
        public ActionResult StatusInactive(int id)
        {
            try
            {
            AspCMSNotice Notice = db.AspCMSNotices.Find(id);
            if (Notice == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSNotice] SET [NoticeStatus] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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
            AspCMSNotice Notice = db.AspCMSNotices.Find(id);
            if (Notice == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSNotice] SET [NoticeStatus] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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
                AspCMSNotice aspCmsNotice = db.AspCMSNotices.Find(id);
                if (aspCmsNotice == null)
                {
                    return HttpNotFound();
                }

                int MinOrder = Global.execInt("Select min(NoticeOrderID) From [AspCMSNotice]");

                if (aspCmsNotice.NoticeOrderID == MinOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int temp1Order = Convert.ToInt32(aspCmsNotice.NoticeOrderID);
                    int tempOrder = Global.execInt("Select max(NoticeOrderID) From AspCMSNotice where NoticeOrderID<'" + aspCmsNotice.NoticeOrderID + "'");
                    int temp1ID = Convert.ToInt32(aspCmsNotice.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSNotice WHERE NoticeOrderID='" + tempOrder + "'");



                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNotice SET NoticeOrderID=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNotice SET NoticeOrderID=" + tempOrder + " WHERE ID=" + temp1ID);
                    aspCmsNotice.ModifyBy = User.Identity.GetUserName();
                    aspCmsNotice.ModifyDate = DateTime.Now;
                    db.Entry(aspCmsNotice).State = EntityState.Modified;



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
                AspCMSNotice aspCmsNotice = db.AspCMSNotices.Find(id);
                if (aspCmsNotice == null)
                {
                    return HttpNotFound();
                }


                int MaxOrder = Global.execInt("Select max(NoticeOrderID) From AspCMSNotice");
                if (aspCmsNotice.NoticeOrderID == MaxOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int tempOrder = Global.execInt("Select min(NoticeORderID) From AspCMSNotice where NoticeORderID>'" + aspCmsNotice.NoticeOrderID + "'");
                    int temp1Order = Convert.ToInt32(aspCmsNotice.NoticeOrderID);
                    int temp1ID = Convert.ToInt32(aspCmsNotice.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSNotice WHERE NoticeOrderID='" + tempOrder + "'");

                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNotice SET NoticeORderID=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNotice SET NoticeORderID=" + tempOrder + " WHERE ID=" + temp1ID);

                    aspCmsNotice.ModifyBy = User.Identity.GetUserName();
                    aspCmsNotice.ModifyDate = DateTime.Now;
                    db.Entry(aspCmsNotice).State = EntityState.Modified;


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
        public ActionResult AllNotice()
        {
            try
            {
            List<dynamic> Information = Global.Sql(db, "select  [ID],[NoticeID],[NoticeName],[NoticeDate],[NoticeOrderID],[EntryDate] from [dbo].[AspCMSNotice] where  [NoticeStatus]=1 order by [NoticeDate] DESC").ToList();

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
        public ActionResult NoticeDetails(int id)
        {
            try
            {
            List<dynamic> Information = Global.Sql(db, "select  * from [dbo].[AspCMSNotice] where NoticeID='"+id+ "' and  [NoticeStatus]=1 order by [NoticeOrderID] ASC").ToList();
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