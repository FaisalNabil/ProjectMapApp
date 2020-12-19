using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MangroveSpace.ViewModel;
using MangroveSpace;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductInfoesController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: ProductInfoes
        public ActionResult Index()
        {
            try
            {

            var viewModel = new ProductInfoesViewModel
            {
                AspCMSProductInfoes = Global.Sql(db, "SELECT [ID], [ProductID],[CategoryID],[Product],[Brand],[CategoryName],[Status],[FeaturedStatus] FROM [dbo].[ProductInfoView]").ToList(),
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




        // GET: ProductInfoes/Create
        public ActionResult Create()
        {
            try
            {
            var aspCMSProductInfo = new AspCMSProductInfo();
            aspCMSProductInfo.ProductID = db.Database.SqlQuery<string>("SELECT [dbo].[GenProductInfo](2)").Single();
            var viewModel = new ProductInfoesViewModel
            {
                AspCMSProductInfo = aspCMSProductInfo,
                AspCMSProductCategorys = Global.Sql(db, "SELECT [Id],[CategoryID],[CategoryName] FROM [AspCMSProductCategory]").ToList(),


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

        // POST: ProductInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,BarCode,Product,ProductSlag,Brand,BrandInfo,CategoryID,Color,Unit,WebSellRate,WebBuyRate,WebSellPreRate,Status,FeaturedStatus,InVal,SubSectorID,Vat,CreateDate,SNID,Warranty,UIDENTITY,img1,img2,img3,img4,img5,FeatureImgPath,Description1,Description2,Description3,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSProductInfo aspCMSProductInfo, HttpPostedFileBase ImageFile, HttpPostedFileBase ImageFile2, HttpPostedFileBase ImageFile3, HttpPostedFileBase ImageFile4, HttpPostedFileBase ImageFile5, HttpPostedFileBase ImageFile6)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile.FileName);
                    AttachFileName = aspCMSProductInfo.ProductID + attachFileExt;
                    var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("~/Uploads/CategoryIcon/"), AttachFileName);
                    ImageFile.SaveAs(AttachFileName);
                    aspCMSProductInfo.img1 = AttachFolderPath;
                }

                if (ImageFile2 != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile2.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile2.FileName);
                    AttachFileName = aspCMSProductInfo.ProductID + attachFileExt;
                    var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("~/Uploads/CategoryIcon/"), AttachFileName);
                    ImageFile2.SaveAs(AttachFileName);
                    aspCMSProductInfo.img2 = AttachFolderPath;
                }

                if (ImageFile3 != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile3.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile3.FileName);
                    AttachFileName = aspCMSProductInfo.ProductID + attachFileExt;
                    var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("~/Uploads/CategoryIcon/"), AttachFileName);
                    ImageFile3.SaveAs(AttachFileName);
                    aspCMSProductInfo.img3 = AttachFolderPath;
                }
                if (ImageFile4 != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile4.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile4.FileName);
                    AttachFileName = aspCMSProductInfo.ProductID + attachFileExt;
                    var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("~/Uploads/CategoryIcon/"), AttachFileName);
                    ImageFile4.SaveAs(AttachFileName);
                    aspCMSProductInfo.img4 = AttachFolderPath;
                }

                if (ImageFile5 != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile5.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile5.FileName);
                    AttachFileName = aspCMSProductInfo.ProductID + attachFileExt;
                    var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("~/Uploads/CategoryIcon/"), AttachFileName);
                    ImageFile5.SaveAs(AttachFileName);
                    aspCMSProductInfo.img5 = AttachFolderPath;
                }

                if (ImageFile6 != null)
                {
                    var AttachFileName = Path.GetFileNameWithoutExtension(ImageFile6.FileName);
                    var attachFileExt = Path.GetExtension(ImageFile6.FileName);
                    AttachFileName = aspCMSProductInfo.ProductID + attachFileExt;
                    var AttachFolderPath = "/Uploads/CategoryIcon/" + AttachFileName;

                    AttachFileName = Path.Combine(Server.MapPath("~/Uploads/CategoryIcon/"), AttachFileName);
                    ImageFile6.SaveAs(AttachFileName);
                    aspCMSProductInfo.FeatureImgPath = AttachFolderPath;
                }

                aspCMSProductInfo.EntryDate = DateTime.Now;
                aspCMSProductInfo.ModifyDate = DateTime.Now;
                aspCMSProductInfo.EntryBy = User.Identity.GetUserName();
                aspCMSProductInfo.ModifyBy = User.Identity.GetUserName();
                db.AspCMSProductInfoes.Add(aspCMSProductInfo);
                db.SaveChanges();
                TempData["msg"] = "Successfuly Saved";
                return RedirectToAction("Index");
            }

            var aspCMSProductInfoes = new AspCMSProductInfo();
            var viewModel = new ProductInfoesViewModel
            {
                AspCMSProductInfo = aspCMSProductInfo,
                AspCMSProductCategorys = Global.Sql(db, "SELECT [Id],[CategoryID],[CategoryName] FROM [AspCMSProductCategory]").ToList(),

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

        // GET: ProductInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSProductInfo aspCMSProductInfo = db.AspCMSProductInfoes.Find(id);
            if (aspCMSProductInfo == null)
            {
                return HttpNotFound();
            }
            return View(aspCMSProductInfo);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }

        }

        // POST: ProductInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,BarCode,Product,ProductSlag,Brand,BrandInfo,CategoryID,Color,Unit,WebSellRate,WebBuyRate,WebSellPreRate,Status,FeaturedStatus,InVal,SubSectorID,Vat,CreateDate,SNID,Warranty,UIDENTITY,img1,img2,img3,img4,img5,FeatureImgPath,Description1,Description2,Description3,EntryDate,EntryBy,ModifyDate,ModifyBy")] AspCMSProductInfo aspCMSProductInfo)
        {
            try
            {
            if (ModelState.IsValid)
            {
                db.Entry(aspCMSProductInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspCMSProductInfo);

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
        public ActionResult Delete(int? id)
        {
            try
            {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspCMSProductInfo productInfo = db.AspCMSProductInfoes.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            else
            {

                db.AspCMSProductInfoes.Remove(productInfo);
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
            AspCMSProductInfo productInfo = db.AspCMSProductInfoes.Find(id);
                if (productInfo == null)
                {
                    return HttpNotFound();
                }

                db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSProductInfo] SET [Status] = '" + 0 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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
            AspCMSProductInfo productInfo = db.AspCMSProductInfoes.Find(id);
                if (productInfo == null)
                {
                    return HttpNotFound();
                }

                db.Database.ExecuteSqlCommand("UPDATE [dbo].[AspCMSProductInfo] SET [Status] = '" + 1 + "', ModifyDate = '" + DateTime.Now + "', ModifyBy = '" + User.Identity.GetUserId() + "' where ID = '" + id + "' ");
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




    }
}
