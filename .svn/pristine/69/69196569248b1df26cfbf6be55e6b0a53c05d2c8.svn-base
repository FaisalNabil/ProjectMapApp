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
    public class ProductCategoryController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        // GET: ProductCategory
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            List<dynamic> ProductCategory = Global.Sql(db, "SELECT *FROM [dbo].[AspCMSProductCategory] ORDER BY OrderBY ASC").ToList();
            return View(ProductCategory);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var aspCMSProductCategory = new AspCMSProductCategory();
            aspCMSProductCategory.CategoryID = db.Database.SqlQuery<string>("SELECT [dbo].[GenProductCategory](2)").Single();
            return View(aspCMSProductCategory);
        }

        [Authorize]
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,CategoryName,SubCategoryName,CategoryLogic,CategoryIcon,Status,OrderBY,AccessID,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSProductCategory aspCMSProductCategory, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                //Saving image
                if (ImageFile != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile.FileName);
                    AttachFileName = aspCMSProductCategory.CategoryID + attachFileExt;
                    var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("~/Uploads/CategoryIcon/"), AttachFileName);
                    ImageFile.SaveAs(AttachFileName);
                    aspCMSProductCategory.CategoryIcon = AttachFolderPath;
                }

                aspCMSProductCategory.EntryDate = DateTime.Now;
                aspCMSProductCategory.EntryBy = User.Identity.GetUserName();
                aspCMSProductCategory.ModifyBy = User.Identity.GetUserName();
                aspCMSProductCategory.ModifyDate = DateTime.Now;
                aspCMSProductCategory.OrderBY = db.Database.SqlQuery<int>("SELECT ISNULL(MAX([OrderBY])+1,1) FROM [dbo].[AspCMSProductCategory]").Single();
                db.AspCMSProductCategories.Add(aspCMSProductCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspCMSProductCategory);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            AspCMSProductCategory aspCMSProductCategory = db.AspCMSProductCategories.Find(id);
            if (aspCMSProductCategory == null)
                return HttpNotFound();

            return View(aspCMSProductCategory);
        }


        [Authorize]
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryID,CategoryName,SubCategoryName,CategoryLogic,CategoryIcon,Status,OrderBY,AccessID,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSProductCategory aspCMSProductCategory, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ImageFile != null)
                    {
                        var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        var attachFileExt = Path.GetExtension(ImageFile.FileName);
                        AttachFileName = aspCMSProductCategory.CategoryID + attachFileExt;
                        var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                        AttachFileName = Path.Combine(Server.MapPath("/Uploads/CategoryIcon/"), AttachFileName);
                        ImageFile.SaveAs(AttachFileName);
                        aspCMSProductCategory.CategoryIcon = AttachFolderPath;


                        aspCMSProductCategory.ModifyBy = User.Identity.GetUserName();
                        aspCMSProductCategory.ModifyDate = DateTime.Now;
                        db.Entry(aspCMSProductCategory).State = EntityState.Modified;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    aspCMSProductCategory.ModifyBy = User.Identity.GetUserName();
                    aspCMSProductCategory.ModifyDate = DateTime.Now;
                    db.Entry(aspCMSProductCategory).State = EntityState.Modified;
                    db.Entry(aspCMSProductCategory).Property(e => e.CategoryIcon).IsModified = false;
                    db.Entry(aspCMSProductCategory).Property(e => e.OrderBY).IsModified = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(aspCMSProductCategory);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,ActionName,ControllerName,ErrorTime,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult StatusInactive(int? id)
        {
            try
            {
                AspCMSProductCategory aspCMSProductCategory = db.AspCMSProductCategories.Find(id);
                if (aspCMSProductCategory == null)
                    return HttpNotFound();

                db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSProductCategory] SET [Status] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' WHERE ID = '" + id + "' ");
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


        public ActionResult StatusActive(int? id)
        {
            try
            {
                AspCMSProductCategory aspCMSProductCategory = db.AspCMSProductCategories.Find(id);

                if (aspCMSProductCategory == null)
                    return HttpNotFound();

                db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSProductCategory] SET [Status] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' WHERE ID = '" + id + "' ");
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


        //Increment
        public ActionResult Increment(int? id)
        {

            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                AspCMSProductCategory aspCMSProductCategory = db.AspCMSProductCategories.Find(id);

                if (aspCMSProductCategory == null)
                    return HttpNotFound();

                int MinOrder = Global.execInt("SELECT MIN([OrderBY]) FROM AspCMSProductCategory");

                if (aspCMSProductCategory.OrderBY == MinOrder)
                    return Redirect(Request.UrlReferrer.ToString());
              
                else
                {
                    int CurrentOrder = Convert.ToInt32(aspCMSProductCategory.OrderBY);
                    int LessMaxOrder = Global.execInt("SELECT MAX(OrderBY) FROM AspCMSProductCategory WHERE OrderBY<'" + aspCMSProductCategory.OrderBY + "'");
                    int CurrentOrderID = Convert.ToInt32(aspCMSProductCategory.ID);
                    int LessMaxOrderID = Global.execInt("SELECT ID FROM AspCMSProductCategory WHERE OrderBY='" + LessMaxOrder + "'");

                    db.Database.ExecuteSqlCommand("UPDATE AspCMSProductCategory SET OrderBY=" + CurrentOrder + "WHERE ID=" + LessMaxOrderID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSProductCategory SET OrderBY=" + LessMaxOrder + " WHERE ID=" + CurrentOrderID);
                    aspCMSProductCategory.ModifyBy = User.Identity.GetUserName();
                    aspCMSProductCategory.ModifyDate = DateTime.Now;
                    db.Entry(aspCMSProductCategory).State = EntityState.Modified;

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


        //Decrement
        public ActionResult Decrement(int? id)
        {

            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                AspCMSProductCategory aspCMSProductCategory = db.AspCMSProductCategories.Find(id);

                if (aspCMSProductCategory == null)
                    return HttpNotFound();

                int MinOrder = Global.execInt("SELECT MAX([OrderBY]) FROM AspCMSProductCategory");

                if (aspCMSProductCategory.OrderBY == MinOrder)
                    return Redirect(Request.UrlReferrer.ToString());

                else
                {
                    int CurrentOrder = Convert.ToInt32(aspCMSProductCategory.OrderBY);
                    int LessMaxOrder = Global.execInt("SELECT MAX(OrderBY) FROM AspCMSProductCategory WHERE OrderBY>'" + aspCMSProductCategory.OrderBY + "'");
                    int CurrentOrderID = Convert.ToInt32(aspCMSProductCategory.ID);
                    int LessMaxOrderID = Global.execInt("SELECT ID FROM AspCMSProductCategory WHERE OrderBY='" + LessMaxOrder + "'");

                    db.Database.ExecuteSqlCommand("UPDATE AspCMSProductCategory SET OrderBY=" + CurrentOrder + "WHERE ID=" + LessMaxOrderID);
                    db.Database.ExecuteSqlCommand("UPDATE AspCMSProductCategory SET OrderBY=" + LessMaxOrder + " WHERE ID=" + CurrentOrderID);
                    aspCMSProductCategory.ModifyBy = User.Identity.GetUserName();
                    aspCMSProductCategory.ModifyDate = DateTime.Now;
                    db.Entry(aspCMSProductCategory).State = EntityState.Modified;

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
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSProductCategory aspCMSProductCategory = db.AspCMSProductCategories.Find(id);
                if (aspCMSProductCategory == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.AspCMSProductCategories.Remove(aspCMSProductCategory);
                    db.SaveChanges();
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