using MangroveSpace;
using MapProject.Models;
using MapProject.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapProject.Controllers
{
    public class ExcelImportController : Controller
    {
        private MangroveSpaceEntities db = new MangroveSpaceEntities();
        // GET: ExcelImport
        public ActionResult Index()
        {
            try
            {
                if (Session["Result"] != null)
                {
                    ViewBag.Result = Session["Result"].ToString();
                }
                else
                {
                    ViewBag.Result = string.Empty;
                }
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

        [HttpPost]
        public ActionResult Import(ImportExcel importExcel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string path = Server.MapPath("~/Content/Upload/" + importExcel.file.FileName);
                    importExcel.file.SaveAs(path);

                    string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                    string tableName = "Data$";

                    DataTable dt;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(
                        "Select * from [" + tableName + "]", excelConnection))
                    {
                        dt = new DataTable(tableName);
                        da.Fill(dt);
                    }

                    ImportHelper helper = new ImportHelper();
                    string i = string.Empty;

                    if (importExcel.FileForType == FileFor.General)
                    {
                        i = helper.GeneralDataImport(dt, User.Identity.GetUserName().ToString());
                    }
                    else if (importExcel.FileForType == FileFor.SubSystem)
                    {
                        i = helper.TechnicalDataImport(dt, User.Identity.GetUserName().ToString());
                    }
                    excelConnection.Close();

                    Session["Result"] = i;

                }
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