using MangroveSpace;
using MapProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapProject.Controllers
{
    public class ComparisonController : Controller
    {
        MangroveSpaceEntities db = new MangroveSpaceEntities();
        ComparisonDataPreparation compService = new ComparisonDataPreparation();
        // GET: Comparison
        public ActionResult Index(int? item)
        {
            List<dynamic> ListItem1 = Global.Sql(db, "SELECT [ID],[Loc_Name] FROM [dbo].[PowerPlant_General]").ToList();
            List<dynamic> ListItem2 = Global.Sql(db, "SELECT [ID],[Loc_Name] FROM [dbo].[PowerPlant_General]").ToList();
            if (item != 0 && item != null)  
            {
                ListItem1 = Global.Sql(db, "SELECT [ID],[Loc_Name] FROM [dbo].[PowerPlant_General] WHERE ID = "+item).ToList();
            }
            ViewBag.ListItem1 = ListItem1;
            ViewBag.ListItem2 = ListItem2;

            return View();
        }

        public JsonResult GetComparisonData(string item1, string item2)
        {
            int i1 = Convert.ToInt32(item1);
            int i2 = Convert.ToInt32(item2);
            var data = compService.GetBridgeChangeData(i1, i2);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}