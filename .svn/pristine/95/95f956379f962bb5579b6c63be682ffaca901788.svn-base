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
using MangroveSpace.ViewModel;
namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class AlbumsController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        // GET: Albums
        public ActionResult Index()
        {
            try
            {
                IEnumerable<dynamic> aspCmsAlbum = Global.Sql(db, "SELECT [ID],[AID],[AlbumTitle],[AlbumOrder],[CDate],Status FROM [dbo].[AspCMSAlbum]").ToList();
                return View(aspCmsAlbum);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        // GET: Albums/Details/5
        /*  public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              AspCMSAlbum aspCMSAlbum = db.AspCMSAlbums.Find(id);
              if (aspCMSAlbum == null)
              {
                  return HttpNotFound();
              }
              return View(aspCMSAlbum);
          }*/

        // GET: Albums/Create
        public ActionResult Create()
        {
            try
            {
                var aspCmsAlbum = new AspCMSAlbum();
                aspCmsAlbum.AID = db.Database.SqlQuery<string>("select dbo.GenCmsAlbumID(2)").Single();

                var viewModel = new AlbumPakageViewModel
                {
                    AspCMSAlbum = aspCmsAlbum
                };

                return View(aspCmsAlbum);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AID,CDate,AlbumTitle,AlbumDescription,AlbumDefault,AlbumOrder,Status,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSAlbum aspCMSAlbum, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aspCMSAlbum.EntryDate = DateTime.Now;
                    aspCMSAlbum.EntryBy = User.Identity.GetUserName();
                    aspCMSAlbum.ModifyBy = User.Identity.GetUserName();
                    aspCMSAlbum.ModifyDate = DateTime.Now;
                    aspCMSAlbum.Status = true;
                    if (ImageFile != null)
                    {
                        var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        var attachFileExt = Path.GetExtension(ImageFile.FileName);
                        AttachFileName = aspCMSAlbum.AID + attachFileExt;
                        var AttachFolderPath = "/Uploads/AlbumCover/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("/Uploads/AlbumCover/"), AttachFileName);
                        //ImageFile = Global.ResizeImage(ImageFile,110,140)
                        ImageFile.SaveAs(AttachFileName);
                        aspCMSAlbum.AlbumImage = AttachFolderPath;
                    }


                    db.AspCMSAlbums.Add(aspCMSAlbum);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                var viewModel = new AlbumPakageViewModel
                {
                    AspCMSAlbum = aspCMSAlbum

                };

                return View(aspCMSAlbum);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSAlbum aspCMSAlbum = db.AspCMSAlbums.Find(id);
                if (aspCMSAlbum == null)
                {
                    return HttpNotFound();
                }

                ViewBag.ImagePath = aspCMSAlbum.AlbumImage;
                var aspCmsAlbulDetail = new AspCMSAlbumDetail();
                aspCmsAlbulDetail.ADID = db.Database.SqlQuery<string>("select dbo.GenCmsAlbumDetailsID(2)").Single();
                var viewModel = new AlbumPakageViewModel
                {
                    AspCMSAlbum = aspCMSAlbum,
                    aspCMSAlbumDetail = aspCmsAlbulDetail,
                    AspCMSAlbumDetails = Global.Sql(db, "SELECT [ID],[AID],[ADID],[Status],[AlbumDetailsTitle] FROM [dbo].[AspCMSAlbumDetails] where [AID]='" + aspCMSAlbum.AID + "'"),
                    AspCMSAlbums = Global.Sql(db, "Select [ID],[AID],[AlbumTitle] from [AspCMSAlbum]").ToList(),
                };


                return View(viewModel);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }





        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AID,CDate,AlbumTitle,AlbumDescription,AlbumDefault,AlbumOrder,Status,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSAlbum aspCMSAlbum, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    aspCMSAlbum.ModifyBy = User.Identity.GetUserName();
                    aspCMSAlbum.ModifyDate = DateTime.Now;
                    if (ImageFile != null)
                    {
                        var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        var attachFileExt = Path.GetExtension(ImageFile.FileName);
                        AttachFileName = aspCMSAlbum.AID + attachFileExt;
                        var AttachFolderPath = "/Uploads/AlbumCover/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("/Uploads/AlbumCover/"), AttachFileName);
                        //ImageFile = Global.ResizeImage(ImageFile,110,140)
                        ImageFile.SaveAs(AttachFileName);
                        aspCMSAlbum.AlbumImage = AttachFolderPath;
                        db.Entry(aspCMSAlbum).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    db.Entry(aspCMSAlbum).State = EntityState.Modified;
                    db.Entry(aspCMSAlbum).Property(e => e.AlbumImage).IsModified = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                var aspcmsalbumdetails = new AspCMSAlbumDetail();

                var viewModel = new AlbumPakageViewModel
                {
                    AspCMSAlbum = aspCMSAlbum,
                    aspCMSAlbumDetail = aspcmsalbumdetails

                };


                return View(viewModel);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        public ActionResult Preview(int id)
        {
            try
            {

            var aspCmsAlbumDetail = db.AspCMSAlbumDetails.SingleOrDefault(c => c.ID == id);
            if (aspCmsAlbumDetail == null)
                return HttpNotFound();
            return View(aspCmsAlbumDetail);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSAlbum aspCMSAlbum = db.AspCMSAlbums.Find(id);
                if (aspCMSAlbum == null)
                {
                    return HttpNotFound();
                }

                db.Database.ExecuteSqlCommand("delete from [dbo].[AspCMSAlbumDetails] where AID='" + aspCMSAlbum.AID + "'");
                db.AspCMSAlbums.Remove(aspCMSAlbum);
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

        [Authorize]
        [HttpGet]
        public ActionResult StatusInactive(int id)
        {
            try
            {
            AspCMSAlbum album = db.AspCMSAlbums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSAlbum] SET [Status] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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
            AspCMSAlbum album = db.AspCMSAlbums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSAlbum] SET [Status] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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

        [AllowAnonymous]
        public ActionResult AlbumDetails(int id)
        {
            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.AlbumID = id;
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

        
        public ActionResult GetImages(string AID)
        {
            try
            {
            string pathString = Server.MapPath("~/Uploads/AlbumImage/" + AID);

            try
            {
                DirectoryInfo directoryName = new DirectoryInfo(pathString);
                FileInfo[] myFile = directoryName.GetFiles();

                var ImageFile = new List<images>();
                foreach (var item in myFile)
                {

                    ImageFile.Add(new images { name = item.Name, path = "/Uploads/AlbumImage/" + AID + "/" + item.Name, size = item.Length });
                }
                return Json(new { Data = ImageFile }, JsonRequestBehavior.AllowGet);


            }
            catch
            {
                return Json(new { Data = "Something Wrong!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UploadPhotos(string AID)
        {
            try
            {
            bool isSavedSuccessfully = true;
            string fName = "";
            // string FileName = "";
            string AttachFileExt = "";
            // int Count;
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    // fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        string pathString = Server.MapPath("~/Uploads/AlbumImage/" + AID + "");
                        bool exists = System.IO.Directory.Exists(pathString);
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        //var directoryName = new DirectoryInfo(pathString);
                        //var IsmyFile = directoryName.GetFiles();


                        //if (IsmyFile.Length == 0)
                        //{
                        //    Count = 1;
                        //}
                        //else
                        //{
                        //    var myFile = IsmyFile.OrderByDescending(f => f.LastWriteTime).First();
                        //    FileName = Path.GetFileNameWithoutExtension(Convert.ToString(myFile));
                        //    var strArray = FileName.Split('-')[1];
                        //    Count = Convert.ToInt32(strArray) + 1;
                        //}
                        string albumDetailsID = db.Database.SqlQuery<string>("select dbo.GenCmsAlbumDetailsID(2)").Single();

                        //Chnage The Image Name
                        AttachFileExt = Path.GetExtension(file.FileName);
                        fName = AID + "-" + albumDetailsID + "-" + AttachFileExt;

                        AspCMSAlbumDetail albumDetail = new AspCMSAlbumDetail();
                        albumDetail.AID = AID;
                        albumDetail.ADID = albumDetailsID;
                        albumDetail.AlbumDetailImagePath = "/Uploads/AlbumImage/" + AID + "/" + fName;
                        albumDetail.Status = true;
                        albumDetail.ModifyDate = DateTime.Now;
                        db.AspCMSAlbumDetails.Add(albumDetail);
                        db.SaveChanges();

                        var path = Path.Combine(pathString, fName);
                        file.SaveAs(path);

                    }

                }

            }
            catch
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Content(fName);
            }
            else
            {
                return Content("Error in saving file");
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



        public ActionResult DeleteImage(string deleteFile)
        {
            try
            {
            var AID = deleteFile.Split('-')[0];
            var ADID = deleteFile.Split('-')[1];

            string filePath = Server.MapPath("~/Uploads/AlbumImage/" + AID + "/" + deleteFile + "");
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                db.Database.ExecuteSqlCommand("delete from AspCMSAlbumDetails Where ADID='"+ ADID +"' and AID='"+ AID +"'");
                return Content("Removed Successfull");

            }
            catch
            {
                return Content("Error in Remove File");
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
