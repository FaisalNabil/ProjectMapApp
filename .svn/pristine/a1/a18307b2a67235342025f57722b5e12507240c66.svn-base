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
    public class AlbumDetailsController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        // GET: AlbumDetails
        public ActionResult Index()
        {
            try
            {

                IEnumerable<dynamic> aspCmsAlbumDetail = Global.Sql(db, "SELECT [ID],[AID],[ADID],[AlbumTitle],[Status] FROM [dbo].[AspCMSAlbumDetailsView]").ToList();
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

        // GET: AlbumDetails/Details/5
        /*  public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              AspCMSAlbumDetail aspCMSAlbumDetail = db.AspCMSAlbumDetails.Find(id);
              if (aspCMSAlbumDetail == null)
              {
                  return HttpNotFound();
              }
              return View(aspCMSAlbumDetail);
          }*/

        // GET: AlbumDetails/Create
        public ActionResult Create()
        {
            try
            {
                var aspCmsAlbumDetail = new AspCMSAlbumDetail();
                aspCmsAlbumDetail.ADID = db.Database.SqlQuery<string>("select dbo.GenCmsAlbumDetailsID(2)").Single();

                ViewBag.AlbumList = Global.Sql(db, "Select [ID],[AID],[AlbumTitle] from [AspCMSAlbum]").ToList();

//                var viewModel = new AlbumPakageDetailsViewModel
//                {
//                    AspCMSAlbumDetail = aspCmsAlbumDetail,
//                    AspCMSAlbum = Global.Sql(db, "Select [ID],[AID],[AlbumTitle] from [AspCMSAlbum]").ToList()
//                };
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

        // POST: AlbumDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ADID,AID,AlbumDetailsTitle,AlbumDetailsDescription,AlbumDetailsOrder,Status,EntryDate,EntryBy,ModifyDate,ModifyBy,AlbumDetailImagePath")] AspCMSAlbumDetail aspCmsAlbumDetail,HttpPostedFileBase ImageFile)
        {
            try
            {

            if (ModelState.IsValid)
              {

                  aspCmsAlbumDetail.EntryDate = DateTime.Now;
                  aspCmsAlbumDetail.EntryBy = User.Identity.GetUserName();
                  aspCmsAlbumDetail.ModifyBy = User.Identity.GetUserName();
                aspCmsAlbumDetail.ModifyDate = DateTime.Now;
                if (ImageFile != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile.FileName);
                    AttachFileName = aspCmsAlbumDetail.ADID + attachFileExt;
                    var AttachFolderPath = "/Uploads/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("/Uploads/"), AttachFileName);
                    //ImageFile = Global.ResizeImage(ImageFile,110,140)
                    ImageFile.SaveAs(AttachFileName);
                    aspCmsAlbumDetail.AlbumDetailImagePath = AttachFolderPath;
                }
                aspCmsAlbumDetail.Status = true;
                db.AspCMSAlbumDetails.Add(aspCmsAlbumDetail);
             
                 db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }


                 ViewBag.AlbumList = Global.Sql(db, "Select [ID],[AID],[AlbumTitle],[Status] from [AspCMSAlbum]").ToList();
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

        // GET: AlbumDetails/Edit/5
      /*  public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSAlbumDetail aspCMSAlbumDetail = db.AspCMSAlbumDetails.Find(id);
                if (aspCMSAlbumDetail == null)
                {
                    return HttpNotFound();
                }
                return View(aspCMSAlbumDetail);
            }
            catch (Exception ex)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,ErrorTime,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "', '" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        // POST: AlbumDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ADID,AID,AlbumDetailsTitle,AlbumDetailsDescription,AlbumDetailsOrder,Status,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSAlbumDetail aspCMSAlbumDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    aspCMSAlbumDetail.ModifyBy = User.Identity.GetUserName();
                    aspCMSAlbumDetail.ModifyDate = DateTime.Now;
                    db.Entry(aspCMSAlbumDetail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(aspCMSAlbumDetail);
            }
            catch (Exception ex)
            {
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,ErrorTime,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "', '" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }*/

        // GET: AlbumDetails/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               AspCMSAlbumDetail AspCMSAlbumDetail = db.AspCMSAlbumDetails.Find(id);
                if (AspCMSAlbumDetail == null)
                {
                    return HttpNotFound();
                }
                db.AspCMSAlbumDetails.Remove(AspCMSAlbumDetail);
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


        public ActionResult StatusInactive(int? id)
        {

            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSAlbumDetail aspCMSAlbumDetail = db.AspCMSAlbumDetails.Find(id);
                if (aspCMSAlbumDetail == null)
                {
                    return HttpNotFound();
                }
                aspCMSAlbumDetail.ModifyBy = User.Identity.GetUserName();
                aspCMSAlbumDetail.ModifyDate = DateTime.Now;
                aspCMSAlbumDetail.Status = false;
                db.Entry(aspCMSAlbumDetail).State = EntityState.Modified;
                db.SaveChanges();


                return Redirect(Request.UrlReferrer.ToString());

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }



        public ActionResult StatusActive(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSAlbumDetail aspCMSAlbumDetail = db.AspCMSAlbumDetails.Find(id);
                if (aspCMSAlbumDetail == null)
                {
                    return HttpNotFound();
                }
                aspCMSAlbumDetail.ModifyBy = User.Identity.GetUserName();
                aspCMSAlbumDetail.ModifyDate = DateTime.Now;
                aspCMSAlbumDetail.Status = true;
                db.Entry(aspCMSAlbumDetail).State = EntityState.Modified;
                db.SaveChanges();


                return Redirect(Request.UrlReferrer.ToString());

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

