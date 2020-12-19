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
    public class NewsController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }


        // GET: News
        public ActionResult Index()
         {
            try
            {
            List<dynamic> Information = Global.Sql(db, "select * from [dbo].[AspCMSNews] where [NewsCategory]='1' order by [NewsOrderID] asc").ToList();
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


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsName,AttachFilePath,NewsDescription,NewsStatus,NewsDate")] AspCMSNew news, HttpPostedFileBase AttFile)
        {
            try
            {
            string AttachFileName = "";
            string AttachFileExt = "";
            string AttachFolderPath = "";

            if (ModelState.IsValid)
            {

                int NewsID = db.Database.SqlQuery<Int32>("select isnull(max([NewsID])+1,1) from [AspCMSNews]").Single();
                int NewsOrderID = db.Database.SqlQuery<Int32>("select isnull(max([NewsOrderID])+1,1) from [dbo].[AspCMSNews] where [NewsCategory]=1").Single();
                try
                {
                    string[] validateFile = new string[] { "text/plain", "application/pdf", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "image/jpeg", "image/jpg", "image/png", "image/gif", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
                    string Validate = Global.GetMIMEType(AttFile.FileName);
                    if (validateFile.Contains(Validate))
                    {
                        AttachFileName = Path.GetFileNameWithoutExtension(AttFile.FileName);
                        AttachFileExt = Path.GetExtension(AttFile.FileName);
                        AttachFileName = "Ne" + NewsID + AttachFileExt;
                        AttachFolderPath = "/Uploads/NewsFile/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("~/Uploads/NewsFile/"), AttachFileName);
                        AttFile.SaveAs(AttachFileName);
                        news.AttachFile = AttachFolderPath;

                    }
                    else
                    {
                        TempData["msgs"] = "Please select (pdf,doc,docx,xlx,png,jpeg,jpg,gif)";
                        return View(news);
                    }

                }
                catch
                {
                    TempData["msgs"] = "Somthing Went Wrong";
                    AttachFolderPath = "";
                }
                news.EntryDate = DateTime.Now;
                news.NewsOrderID = news.NewsOrderID;
                news.EntryBy = User.Identity.GetUserId();
                news.NewsID = NewsID;
                news.AttachFile = AttachFolderPath;
                news.NewsStatus = true;
                news.NewsCategory = Convert.ToString(1);
                db.AspCMSNews.Add(news);
                db.SaveChanges();
                TempData["msg"] = "Successfuly Saved";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["msgs"] = "Somthing Went Wrong";
                return View(news);

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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSNew News = db.AspCMSNews.Find(id);
            if (News == null)
            {
                return HttpNotFound();
            }
            return View(News);

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
        public ActionResult Edit([Bind(Include = "ID,NewsName,AttachFile,NewsDescription,NewsStatus,NewsDate")] AspCMSNew news, HttpPostedFileBase AttachFilePath)
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
                        AttachFileName = "No" + news.NewsID + AttachFileExt;
                        AttachFolderPath = "/Content/News/" + AttachFileName;
                        news.AttachFile = AttachFolderPath;
                        AttachFileName = Path.Combine(Server.MapPath("~/Uploads/NewsFile/"), AttachFileName);
                        AttachFilePath.SaveAs(AttachFileName);

                        news.ModifyDate = DateTime.Now;
                        news.ModifyBy = User.Identity.GetUserId();
                        db.Entry(news).State = EntityState.Modified;
                        db.Entry(news).Property(e => e.NewsID).IsModified = false;
                        db.Entry(news).Property(e => e.EntryBy).IsModified = false;
                        db.Entry(news).Property(e => e.EntryDate).IsModified = false;
                        db.Entry(news).Property(e => e.NewsCategory).IsModified = false;
                        db.Entry(news).Property(e => e.NewsID).IsModified = false;
                        db.SaveChanges();
                        TempData["msg"] = "Successfuly Updated";
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["msgs"] = "Please select (pdf,doc,docx,xlx,png,jpeg,jpg,gif)";
                        return View(news);
                    }

                }
                catch
                {

                    AttachFolderPath = "";
                }

                news.ModifyDate = DateTime.Now;
                news.ModifyBy = User.Identity.GetUserId();
                db.Entry(news).State = EntityState.Modified;
                db.Entry(news).Property(e => e.NewsID).IsModified = false;
                db.Entry(news).Property(e => e.EntryBy).IsModified = false;
                db.Entry(news).Property(e => e.EntryDate).IsModified = false;
                db.Entry(news).Property(e => e.NewsCategory).IsModified = false;
                db.Entry(news).Property(e => e.AttachFile).IsModified = false;
                db.Entry(news).Property(e => e.NewsID).IsModified = false;
                db.SaveChanges();
                TempData["msg"] = "Successfuly Updated";
                return RedirectToAction("Index");

            }
            else
            {
                return View(news);

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



        //CodeViewNewsEdit

        [HttpGet]
        public ActionResult CodeViewNewsEdit(int? id)
        {
            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSNew News = db.AspCMSNews.Find(id);
            if (News == null)
            {
                return HttpNotFound();
            }
            return View(News);

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSNew News = db.AspCMSNews.Find(id);


            int NewsOrderID = Convert.ToInt32(News.NewsOrderID);

            if (News == null)
            {
                return HttpNotFound();
            }

            string path = Server.MapPath(News.AttachFile);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            List<dynamic> Information = Global.Sql(db, "select * from [AspCMSNews] where  [NewsOrderID] > '" + NewsOrderID + "' and [NewsCategory] = '" + 1 + "' ").ToList();

            foreach (dynamic i in Information)
            {
                int newNewsOrderID = i.NewsOrderID - 1;

                db.Database.ExecuteSqlCommand("UPDATE AspCMSNews SET NewsOrderID = '" + newNewsOrderID + "' where [ID] = '" + i.ID + "'");
            }
            db.AspCMSNews.Remove(News);
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

        [HttpGet]
        public ActionResult StatusInactive(int id)
        {
            try
            {
            AspCMSNew news = db.AspCMSNews.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSNews] SET [NewsStatus] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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



        [HttpGet]
        public ActionResult StatusActive(int id)
        {
            try
            {
            AspCMSNew news = db.AspCMSNews.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSNews] SET [NewsStatus] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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
                AspCMSNew AspCMSNews = db.AspCMSNews.Find(id);
                if (AspCMSNews == null)
                {
                    return HttpNotFound();
                }

                int MinOrder = Global.execInt("Select min(NewsOrderID) From [AspCMSNews]");

                if (AspCMSNews.NewsOrderID == MinOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int temp1Order = Convert.ToInt32(AspCMSNews.NewsOrderID);
                    int tempOrder = Global.execInt("Select max(NewsOrderID) From AspCMSNews where NewsOrderID<'" + AspCMSNews.NewsOrderID + "'");
                    int temp1ID = Convert.ToInt32(AspCMSNews.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSNews WHERE NewsOrderID='" + tempOrder + "'");



                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNews SET NewsOrderID=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNews SET NewsOrderID=" + tempOrder + " WHERE ID=" + temp1ID);
                    AspCMSNews.ModifyBy = User.Identity.GetUserName();
                    AspCMSNews.ModifyDate = DateTime.Now;
                    db.Entry(AspCMSNews).State = EntityState.Modified;



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
                AspCMSNew AspCMSNews = db.AspCMSNews.Find(id);
                if (AspCMSNews == null)
                {
                    return HttpNotFound();
                }


                int MaxOrder = Global.execInt("Select max(NewsOrderID) From AspCMSNews");
                if (AspCMSNews.NewsOrderID == MaxOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int tempOrder = Global.execInt("Select min(NewsOrderID) From AspCMSNews where NewsOrderID>'" + AspCMSNews.NewsOrderID + "'");
                    int temp1Order = Convert.ToInt32(AspCMSNews.NewsOrderID);
                    int temp1ID = Convert.ToInt32(AspCMSNews.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSNews WHERE NewsOrderID='" + tempOrder + "'");

                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNews SET NewsOrderID=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSNews SET NewsOrderID=" + tempOrder + " WHERE ID=" + temp1ID);

                    AspCMSNews.ModifyBy = User.Identity.GetUserName();
                    AspCMSNews.ModifyDate = DateTime.Now;
                    db.Entry(AspCMSNews).State = EntityState.Modified;


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
        public ActionResult AllNews()
        {
            try
            {
            List<dynamic> Information = Global.Sql(db, "select [ID],[NewsID],[NewsName],[NewsDate],[AttachFile],[NewsOrderID],[EntryDate] from [dbo].[AspCMSNews] where  [NewsStatus]=1 order by [NewsOrderID] asc").ToList();
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
        public ActionResult NewsDetails(int id)
        {
            try
            {
            List<dynamic> Information = Global.Sql(db, "select * from [dbo].[AspCMSNews] where ID='"+id+ "' and [NewsStatus]=1 order by [NewsOrderID] asc").ToList();
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