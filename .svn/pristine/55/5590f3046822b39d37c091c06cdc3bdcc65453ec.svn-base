using MangroveSpace;
using MapProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapProject.Service
{
    public class ComparisonDataPreparation
    {
        MangroveSpaceEntities db = new MangroveSpaceEntities();
        public List<ComparisonModel> GetBridgeChangeData(int item1Id, int item2Id)
        {
            List<ComparisonModel> ComparisonData = new List<ComparisonModel>();
            
            //var item1 =
            //    (from powerPlant_General in db.PowerPlant_General
            //     join powerPlant_Category in db.PowerPlant_Category on powerPlant_General.CategoryID equals powerPlant_Category.ID 
            //     //join powerPlant_Technical in db.PowerPlant_Technical on powerPlant_General.ID equals powerPlant_Technical.Loc_ID
            //     where powerPlant_General.ID == item1Id
            //     select new
            //     {
            //         PowerPlant_Name = powerPlant_General.PowerPlant_Name,
            //         Lat = powerPlant_General.Lat,
            //         @long = powerPlant_General.@long,
            //         Address = powerPlant_General.Address,
            //         Category_Name = powerPlant_Category.Category_Name,
            //         //sp1 = specialized_Table1.sp1,
            //         //sp2 = specialized_Table1.sp2,
            //         //sp3 = specialized_Table1.sp3
            //     }).FirstOrDefault();

            //var item2 =
            //    (from powerPlant_General in db.PowerPlant_General
            //     join powerPlant_Category in db.PowerPlant_Category on powerPlant_General.CategoryID equals powerPlant_Category.ID
            //     //join powerPlant_Technical in db.PowerPlant_Technical on powerPlant_General.ID equals powerPlant_Technical.Loc_ID
            //     where powerPlant_General.ID == item2Id
            //     select new
            //     {
            //         PowerPlant_Name = powerPlant_General.PowerPlant_Name,
            //         Lat = powerPlant_General.Lat,
            //         @long = powerPlant_General.@long,
            //         Address = powerPlant_General.Address,
            //         Category_Name = powerPlant_Category.Category_Name,
            //         //sp1 = specialized_Table1.sp1,
            //         //sp2 = specialized_Table1.sp2,
            //         //sp3 = specialized_Table1.sp3
            //     }).FirstOrDefault();

            //foreach (var sourceProp in item1.GetType().GetProperties())
            //{
            //    Type type = sourceProp.PropertyType;
            //    if (type == typeof(string) || type == typeof(Int32) || type == typeof(Int32?) ||
            //        type == typeof(Decimal) || type == typeof(Decimal?) || type == typeof(DateTime) ||
            //        type == typeof(DateTime?))
            //    {
            //        foreach (var destProperty in item2.GetType().GetProperties())
            //        {
            //            if (destProperty.Name == sourceProp.Name &&
            //                destProperty.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
            //            {
            //                try
            //                {
            //                    ComparisonModel row = new ComparisonModel();
            //                    row.PropName = GetPropName(sourceProp.Name);
            //                    row.Data1 = sourceProp.GetValue(item1, null).ToString();
            //                    row.Data2 = destProperty.GetValue(item2, null).ToString();
            //                    ComparisonData.Add(row);
            //                }
            //                catch (Exception ex)
            //                {

            //                }
            //            }
            //        }
            //    }

            //}


            return ComparisonData;
        }

        private string GetPropName(string dbName)
        {
            if (PropNameDictionary().ContainsKey(dbName))
            {
                return PropNameDictionary()[dbName];
            }
            return dbName;
        }

        private IDictionary<string, string> PropNameDictionary()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Loc_Name", "Name");
            dict.Add("Loc_Latitude", "Latitude");
            dict.Add("Loc_Logitude", "Logitude");
            dict.Add("Address", "Address");
            dict.Add("Category_Name", "Category");

            return dict;
        }

    }
}