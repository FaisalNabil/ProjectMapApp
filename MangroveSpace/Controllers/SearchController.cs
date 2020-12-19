using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace.Controllers
{
    public class SearchController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: Search
        public ActionResult Index()
        {
            try
            {
                Session["Countries"] = null;
                Session["Companies"] = null;
                ViewBag.SearchContent = Session["SearchContent"]?.ToString();
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
        public ActionResult Contents()
        {
            try
            {
                #region Countries
                string countryIds = string.Empty;
                List<string> countryIdList = new List<string>();
                if (Session["Countries"] != null)
                {
                    countryIdList = (List<string>)(Session["Countries"]);
                    foreach (string item in countryIdList)
                    {
                        countryIds += item + ",";
                    }
                }
                if (countryIds.Length > 1)
                    countryIds = countryIds.Substring(0, countryIds.Length - 1);
                #endregion

                #region Company
                string CompanyIds = string.Empty;
                List<string> CompanyIdList = new List<string>();
                if (Session["Companies"] != null)
                {
                    CompanyIdList = (List<string>)(Session["Companies"]);
                    foreach (string item in CompanyIdList)
                    {
                        CompanyIds += "'" + item + "',";
                    }
                }
                if (CompanyIds.Length > 1)
                    CompanyIds = CompanyIds.Substring(0, CompanyIds.Length - 1);
                #endregion

                string ppQuery = "Select g.[DetailsPageAddress] From [dbo].[PowerPlant_Main] g where 1=1";
                string mQuery = "Select t.[DetailsPageAddress] From [dbo].[PowerPlant_Child] t where 1=1";

                if (countryIds != "")
                {
                    ppQuery += " and g.[Country] in (" + countryIds + ")";
                    mQuery += " and t.[Country] in (" + countryIds + ")";
                }

                if (CompanyIds != "")
                {
                    mQuery += " and t.[Company/Manufacturer] in (" + CompanyIds + ")";
                }

                string sql = ppQuery + " union " + mQuery;

                List<dynamic> PageIds = Global.Sql(db, sql).ToList();

                string pageid = string.Empty;

                foreach (var item in PageIds)
                {
                    pageid += "'"+item.DetailsPageAddress + "',";
                }

                if (pageid.Length > 1)
                    pageid = pageid.Substring(0, pageid.Length - 1);

                ViewBag.PageIds = pageid;
                ViewBag.Count = PageIds.Count;

                return PartialView("_Contents");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[AspSysError](UserName,EntryBy,ModifyBy,ActionName,ControllerName,ErrorTime,EntryDate,ModifyDate,ErrorMessage)VALUES('" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + User.Identity.GetUserName().ToString() + "','" + actionName + "','" + controllerName + "', '" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', '" + ex.ToString().Replace("'", "") + "')");
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult SetSearchString(string searchString)
        {
            Session["SearchContent"] = searchString;
            return RedirectToAction("Index");
        }
        public string GetSearchString()
        {
            return Session["SearchContent"]?.ToString();
        }
        public void SetCountry(int? countryId)
        {
            List<string> countryIds = new List<string>();
            if (Session["Countries"] == null)
            {
                countryIds.Add(countryId.ToString());
                Session["Countries"] = countryIds;
            }
            else
            {
                countryIds = (List<string>)(Session["Countries"]);
                if(countryIds.Any(x => x == countryId.ToString()))
                {
                    return;
                }
                else
                {
                    countryIds.Add(countryId.ToString());
                    Session["Countries"] = countryIds;
                }
            }
        }
        public void UnSetCountry(int? countryId)
        {
            List<string> countryIds = new List<string>();
            if (Session["Countries"] != null)
            {
                countryIds = (List<string>)(Session["Countries"]);
                if (countryIds.Any(x => x == countryId.ToString()))
                {
                    countryIds.Remove(countryId.ToString());
                    Session["Countries"] = countryIds;
                }
            }
        }

        public void SetCompany(string companyId)
        {
            List<string> companyIds = new List<string>();
            if (Session["Companies"] == null)
            {
                companyIds.Add(companyId);
                Session["Countries"] = companyIds;
            }
            else
            {
                companyIds = (List<string>)(Session["Companies"]);
                if (companyIds.Any(x => x == companyId))
                {
                    return;
                }
                else
                {
                    companyIds.Add(companyId);
                    Session["Companies"] = companyIds;
                }
            }
        }
        public void UnSetCompany(string companyId)
        {
            List<string> companyIds = new List<string>();
            if (Session["Companies"] != null)
            {
                companyIds = (List<string>)(Session["Companies"]);
                if (companyIds.Any(x => x == companyId))
                {
                    companyIds.Remove(companyId);
                    Session["Companies"] = companyIds;
                }
            }
        }
    }
}