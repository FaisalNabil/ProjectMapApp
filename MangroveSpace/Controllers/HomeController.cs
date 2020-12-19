using MapProject.Models;
using MapProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace.Controllers
{

    public class HomeController : Controller
    {
        MapDataPreparation mapService = new MapDataPreparation();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult MapView()
        {
            return View();
        }

        // GET: Locations
        [HttpGet]
        public ActionResult Map()
        {
            var data = mapService.PrepareAllData();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public List<string> GetCategories()
        {
            var data = mapService.GetCategories();
            return data;
        }

        public ActionResult ComparePowerPlant()
        {
            return View();
        }

        public String GetComparePowerPlantData(string PowerPlant1, string PowerPlant2, string PowerPlant3, string PowerPlant4)
        {
            string tableString = mapService.GetPowerPlantComparison(PowerPlant1, PowerPlant2, PowerPlant3, PowerPlant4);
            return tableString;
        }
        public String GetCompareItemData(string Item1, string Item2, string Item3, string Item4)
        {
            string tableString = mapService.GetItemComparison(Item1, Item2, Item3, Item4);
            return tableString;
        }

        public JsonResult GetTypeWiseFilter(string name, string type)
        {
            List<PowerPlantSearchModel> list = new List<PowerPlantSearchModel>();
            if(type == "PP")
            {
                list = mapService.GetPowerPlantListFilter(name);
            }
            else if(type == "M")
            {
                list = mapService.GetItemListFilter(name);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllListFilter(string name)
        {
            var list = mapService.GetAllListFilter(name);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}