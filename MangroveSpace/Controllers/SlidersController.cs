using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MangroveSpace;
using Microsoft.AspNet.Identity;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SlidersController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        // GET: Sliders
        public ActionResult Index()
        {
            try
            {
                IEnumerable<dynamic> aspCmsSlider = Global.Sql(db, "SELECT [ID],[SliderID],[SliderTitle],[SliderOrder],[ModifyDate],SliderStatus FROM [dbo].[AspCMSSlider] ORDER BY SliderOrder ASC;").ToList();

                return View(aspCmsSlider);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }



        // GET: Sliders/Create
        public ActionResult Create()
        {
            try
            {
                var aspCmsSlider = new AspCMSSlider();
                aspCmsSlider.SliderID = db.Database.SqlQuery<string>("select dbo.GenCmsSliderID(2)").Single();
                return View(aspCmsSlider);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }


        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,SliderID,SliderType,SliderOrder,SliderImagePath,SliderStatus,SliderTitle,SliderDesc,EntryDate,EntryBy,ModifyDate,ModifyBy,SliderFileBase")] AspCMSSlider aspCMSSlider, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aspCMSSlider.EntryDate = DateTime.Now;
                    aspCMSSlider.EntryBy = User.Identity.GetUserName();
                    aspCMSSlider.ModifyBy = User.Identity.GetUserName();
                    aspCMSSlider.ModifyDate = DateTime.Now;
                    aspCMSSlider.SliderStatus = true;
                    var SliderOrder= db.Database.SqlQuery<int>("SELECT isnull(MAX(SliderOrder),1) FROM [AspCMSSlider]").Single() ;
                    aspCMSSlider.SliderOrder = SliderOrder+1;
                    if (ImageFile != null)
                    {
                        var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        var attachFileExt = Path.GetExtension(ImageFile.FileName);
                        AttachFileName = aspCMSSlider.SliderID + attachFileExt;
                        var AttachFolderPath = "/Uploads/Slider/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("/Uploads/Slider/"), AttachFileName);
                        //ImageFile = Global.ResizeImage(ImageFile,110,140)
                        ImageFile.SaveAs(AttachFileName);
                        aspCMSSlider.SliderImagePath = AttachFolderPath;
                    }
                    db.AspCMSSliders.Add(aspCMSSlider);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(aspCMSSlider);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSSlider aspCMSSlider = db.AspCMSSliders.Find(id);
                if (aspCMSSlider == null)
                {
                    return HttpNotFound();
                }
                return View(aspCMSSlider);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }



        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,SliderID,SliderType,SliderOrder,SliderImagePath,SliderStatus,SliderTitle,SliderDesc,EntryDate,EntryBy,ModifyDate,ModifyBy,SliderFileBase")] AspCMSSlider aspCMSSlider, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ImageFile != null)
                    {
                        var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        var attachFileExt = Path.GetExtension(ImageFile.FileName);
                        AttachFileName = aspCMSSlider.SliderID + attachFileExt;
                        var AttachFolderPath = "/Uploads/Slider/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("/Uploads/Slider/"), AttachFileName);
                        ImageFile.SaveAs(AttachFileName);
                        aspCMSSlider.SliderImagePath = AttachFolderPath;


                        aspCMSSlider.ModifyBy = User.Identity.GetUserName();
                        aspCMSSlider.ModifyDate = DateTime.Now;
                        db.Entry(aspCMSSlider).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }



                    aspCMSSlider.ModifyBy = User.Identity.GetUserName();
                    aspCMSSlider.ModifyDate = DateTime.Now;
                    db.Entry(aspCMSSlider).State = EntityState.Modified;
                    db.Entry(aspCMSSlider).Property(e => e.SliderImagePath).IsModified = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(aspCMSSlider);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }




        // Code View Slide Edit
        public ActionResult CodeViewSlideEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSSlider aspCMSSlider = db.AspCMSSliders.Find(id);
                if (aspCMSSlider == null)
                {
                    return HttpNotFound();
                }
                return View(aspCMSSlider);
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
                AspCMSSlider aspCMSSlider = db.AspCMSSliders.Find(id);
                if (aspCMSSlider == null)
                {
                    return HttpNotFound();
                }
                db.AspCMSSliders.Remove(aspCMSSlider);
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


        public ActionResult Increment(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               AspCMSSlider AspCMSSlider = db.AspCMSSliders.Find(id);
                if (AspCMSSlider == null)
                {
                    return HttpNotFound();
                }

                int MinOrder = Global.execInt("Select min(SliderOrder) From [AspCMSSlider]");

                if (AspCMSSlider.SliderOrder == MinOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int temp1Order = Convert.ToInt32(AspCMSSlider.SliderOrder);
                    int tempOrder = Global.execInt("Select max(SliderOrder) From AspCMSSlider where SliderOrder<'" + AspCMSSlider.SliderOrder + "'");
                    int temp1ID = Convert.ToInt32(AspCMSSlider.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSSlider WHERE SliderOrder='" + tempOrder + "'");



                    db.Database.ExecuteSqlCommand("UPDATE AspCMSSlider SET SliderOrder=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSSlider SET SliderOrder=" + tempOrder + " WHERE ID=" + temp1ID);
                    AspCMSSlider.ModifyBy = User.Identity.GetUserName();
                    AspCMSSlider.ModifyDate = DateTime.Now;
                    db.Entry(AspCMSSlider).State = EntityState.Modified;



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
                AspCMSSlider AspCMSSlider = db.AspCMSSliders.Find(id);
                if (AspCMSSlider == null)
                {
                    return HttpNotFound();
                }


                int MaxOrder = Global.execInt("Select max(SliderOrder) From AspCMSSlider");
                if (AspCMSSlider.SliderOrder == MaxOrder)
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {

                    int tempOrder = Global.execInt("Select min(SliderOrder) From AspCMSSlider where SliderOrder>'" + AspCMSSlider.SliderOrder + "'");
                    int temp1Order = Convert.ToInt32(AspCMSSlider.SliderOrder);
                    int temp1ID = Convert.ToInt32(AspCMSSlider.ID);
                    int tempID = Global.execInt("Select ID FROM AspCMSSlider WHERE SliderOrder='" + tempOrder + "'");

                    db.Database.ExecuteSqlCommand("UPDATE AspCMSSlider SET SliderOrder=" + temp1Order + "WHERE ID=" + tempID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSSlider SET SliderOrder=" + tempOrder + " WHERE ID=" + temp1ID);

                    AspCMSSlider.ModifyBy = User.Identity.GetUserName();
                    AspCMSSlider.ModifyDate = DateTime.Now;
                    db.Entry(AspCMSSlider).State = EntityState.Modified;


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


        [Authorize]
        [HttpGet]
        public ActionResult StatusInactive(int id)
        {
            try
            {
            AspCMSSlider slider = db.AspCMSSliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSSlider] SET [SliderStatus] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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
            AspCMSSlider slider = db.AspCMSSliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }

            db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSSlider] SET [SliderStatus] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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
