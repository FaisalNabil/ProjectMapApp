using MangroveSpace.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using MapProject.Service;

namespace MangroveSpace.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class PagesController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();
        MapDataPreparation mapService = new MapDataPreparation();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Pages
        [Authorize]
        public ActionResult Index()
        {
            try
            {

                string sql = "select A.[ID], PageID, PageTitle, PageTamplateID, PageLanguage, B.[CategoryName], C.[TemplateName] from [dbo].[AspCMSPage] A Left join [dbo].[AspCMSCategory] B on A.[CategoryID] = B.[CategoryID] Left join [dbo].[AspCMSPageTemplate] C on A.[PageTamplateID] = C.[TemplateID] where A.TAG IS NULL OR A.TAG NOT IN ('PP', 'M')";

                List<dynamic> Information = Global.Sql(db, sql).ToList();
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
        public ActionResult Create()
        {
            try
            {
                var CategoryList = db.Database.SqlQuery<IntList>("select [CategoryID] as [ID], isnull( [CategoryName],'')+ ' > ' + isnull([CategoryContentType],'') as [value] from [dbo].[AspCMSCategory] order by [CategoryID]").ToList();
                ViewBag.CategoryList = CategoryList;

                var TemplateList = db.Database.SqlQuery<StringList>("select [TemplateID] as [ID], isnull([TemplateName],'') as [value]  from [dbo].[AspCMSPageTemplate]").ToList();
                ViewBag.TemplateList = TemplateList;

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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,PageID,PageTitle,PageBody,PageTamplateID,PageType,PageLanguage,"+
            "Aproved,ApprovedBy,CategoryID,TAG")] AspCMSPage aspCMSPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int count = 0;
                    string PageID = Convert.ToString(aspCMSPage.PageTitle);
                    PageID = PageID.Replace(" ", "");

                Ck:
                    int ck_name = Global.exec("select count(*) from AspCMSPage where PageID ='" + PageID + "'", 0);
                    if (ck_name != 0)
                    {
                        count++;
                        PageID = PageID + Convert.ToString(count);
                        goto Ck;
                    }


                    aspCMSPage.PageID = PageID;
                    aspCMSPage.EntryBy = User.Identity.GetUserId();
                    aspCMSPage.EntryDate = DateTime.Now;
                    aspCMSPage.Aproved = true;
                    aspCMSPage.ApprovedBy = User.Identity.GetUserId();
                    db.AspCMSPages.Add(aspCMSPage);
                    db.SaveChanges();
                    TempData["msg"] = "Data Successfuly Saved";
                    return RedirectToAction("Index");

                }
                var CategoryList = db.Database.SqlQuery<IntList>("select [CategoryID] as [ID], isnull( [CategoryName],'')+ ' > ' + isnull([CategoryContentType],'') as [value] from [dbo].[AspCMSCategory] order by [CategoryID]").ToList();
                ViewBag.CategoryList = CategoryList;

                var TemplateList = db.Database.SqlQuery<StringList>("select [TemplateID] as [ID], isnull([TemplateName],'') as [value]  from [dbo].[AspCMSPageTemplate]").ToList();
                ViewBag.TemplateList = TemplateList;

                return View(aspCMSPage);

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
        [ValidateInput(false)]
        public ActionResult Edit(int id)
        {
            try
            {
                var CategoryList = db.Database.SqlQuery<IntList>("select [CategoryID] as [ID], isnull( [CategoryName],'')+ ' > ' + isnull([CategoryContentType],'') as [value] from [dbo].[AspCMSCategory] order by [CategoryID]").ToList();
                ViewBag.CategoryList = CategoryList;

                var TemplateList = db.Database.SqlQuery<StringList>("select [TemplateID] as [ID], isnull([TemplateName],'') as [value]  from [dbo].[AspCMSPageTemplate]").ToList();
                ViewBag.TemplateList = TemplateList;

                //var HtmString  = db.Database.SqlQuery<String>("select [TemplateID] as [ID], isnull([TemplateName],'') as [value]  from [dbo].[AspCMSPageTemplate]").S;

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSPage aspCMSPage = db.AspCMSPages.Find(id);
                if (aspCMSPage == null)
                {
                    return HttpNotFound();
                }
                return View(aspCMSPage);

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
        public ActionResult Edit([Bind(Include = "ID,PageTitle,PageBody,PageTamplateID,PageType,PageLanguage,CategoryID,TAG")] AspCMSPage aspCMSPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aspCMSPage.ModifyDate = DateTime.Now;
                    aspCMSPage.ModifyBy = User.Identity.GetUserId();
                    db.Entry(aspCMSPage).State = EntityState.Modified;
                    db.Entry(aspCMSPage).Property(e => e.PageID).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.EntryBy).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.EntryDate).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.Aproved).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.ApprovedBy).IsModified = false;
                    db.SaveChanges();

                    TempData["msg"] = "Data Successfuly Updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    var CategoryList = db.Database.SqlQuery<IntList>("select [CategoryID] as [ID], isnull( [CategoryName],'')+ ' > ' + isnull([CategoryContentType],'') as [value] from [dbo].[AspCMSCategory] order by [CategoryID]").ToList();
                    ViewBag.CategoryList = CategoryList;

                    var TemplateList = db.Database.SqlQuery<StringList>("select [TemplateID] as [ID], isnull([TemplateName],'') as [value]  from [dbo].[AspCMSPageTemplate]").ToList();
                    ViewBag.TemplateList = TemplateList;

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
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult pageCodeEdit(int id)
        {
            try
            {
                var CategoryList = db.Database.SqlQuery<IntList>("select [CategoryID] as [ID], isnull( [CategoryName],'')+ ' > ' + isnull([CategoryContentType],'') as [value] from [dbo].[AspCMSCategory] order by [CategoryID]").ToList();
                ViewBag.CategoryList = CategoryList;

                var TemplateList = db.Database.SqlQuery<StringList>("select [TemplateID] as [ID], isnull([TemplateName],'') as [value]  from [dbo].[AspCMSPageTemplate]").ToList();
                ViewBag.TemplateList = TemplateList;

                //var HtmString  = db.Database.SqlQuery<String>("select [TemplateID] as [ID], isnull([TemplateName],'') as [value]  from [dbo].[AspCMSPageTemplate]").S;

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspCMSPage aspCMSPage = db.AspCMSPages.Find(id);
                if (aspCMSPage == null)
                {
                    return HttpNotFound();
                }
                return View(aspCMSPage);

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
        public ActionResult pageCodeEdit([Bind(Include = "ID,PageTitle,PageBody,PageTamplateID,PageType,PageLanguage,CategoryID,TAG")] AspCMSPage aspCMSPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aspCMSPage.ModifyDate = DateTime.Now;
                    aspCMSPage.ModifyBy = User.Identity.GetUserId();
                    db.Entry(aspCMSPage).State = EntityState.Modified;
                    db.Entry(aspCMSPage).Property(e => e.PageID).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.EntryBy).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.EntryDate).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.Aproved).IsModified = false;
                    db.Entry(aspCMSPage).Property(e => e.ApprovedBy).IsModified = false;
                    db.SaveChanges();

                    TempData["msg"] = "Data Successfuly Updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
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
                AspCMSPage aspCMSPage = db.AspCMSPages.Find(id);
                if (aspCMSPage == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.AspCMSPages.Remove(aspCMSPage);
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

        [AllowAnonymous]
        [Route("Page")]
        public ActionResult page(string pid)
        {
            try
            {
                AspCMSPage aspCmsPage = db.AspCMSPages.FirstOrDefault(m => m.PageID == pid);
                ViewBag.Title = aspCmsPage.PageTitle;
                ViewBag.Page = "Page";
                ViewBag.Name = "Page Name";
                ViewBag.Page = "Page";
                ViewBag.pageid = pid;
                ViewBag.PostedDate = aspCmsPage.EntryDate;
                ViewBag.Tag = aspCmsPage.TAG;

                string htmlPage = GlobalMethod.exec("SELECT [PageBody] FROM [AspCMSPage] where PageID = '" + pid + "'");

                if (aspCmsPage.TAG == "PP")
                {
                    PowerPlant_Main PowerPlant_Main = mapService.GetPowerPlant(pid);
                    if (!string.IsNullOrEmpty(htmlPage) && htmlPage.Contains("[Table]"))
                    {
                        string TableData = mapService.TableData(true, PowerPlant_Main.ID);
                        htmlPage = htmlPage.Replace("[Table]", TableData);
                    }
                }
                else if (aspCmsPage.TAG == "M")
                {
                    PowerPlant_Child PowerPlant_Child = mapService.GetItem(pid);
                    if (!string.IsNullOrEmpty(htmlPage) && htmlPage.Contains("[Table]"))
                    {
                        string TableData = mapService.TableData(false, PowerPlant_Child.ID);
                        htmlPage = htmlPage.Replace("[Table]", TableData);
                    }
                }

                ViewBag.PageDetails = htmlPage;
                ViewBag.template = GlobalMethod.exec("select top 1 [TemplatePath] from [AspCMSPageTemplate] where [TemplateID] in (select [PageTamplateID] from [AspCMSPage] where PageID = N'" + pid + "')");
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
        public ActionResult save()
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
        public ActionResult save(string hiddentText, string PageName)

        {
            try
            {
                if (hiddentText != "")
                {
                    hiddentText = hiddentText.Replace("'", "\"");
                    GlobalMethod.exec("Update [AspCMSPage] Set PageBody = N'" + hiddentText + "' where PageID = '" + PageName + "'");
                }

                if (PageName == "Home") { return RedirectToAction("", "Home"); }
                else { return RedirectToAction("Page", "Pages", new { pid = PageName }); }

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