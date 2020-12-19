using MangroveSpace;
using MangroveSpace.Models;
using MapProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapProject.Service
{
    public class MapDataPreparation
    {
        MangroveSpaceEntities context = new MangroveSpaceEntities();
        public List<MapDataModel> PrepareAllData()
        {
            List<PowerPlant_Main> MapDataList = context.PowerPlant_Main.ToList();
            List<MapDataModel> dataList = new List<MapDataModel>();
            foreach (var item in MapDataList)
            {
                dataList.Add(PrepareData(item));
            }

            return dataList;
        }

        private MapDataModel PrepareData(PowerPlant_Main MapData)
        {
            MapDataModel data = new MapDataModel();
            PowerPlant_Category category = context.PowerPlant_Category.Where(s => s.ID == MapData.Basic_Category).FirstOrDefault();
            if (category == null)
                category = new PowerPlant_Category();

            PowerPlant_SubCategory subcategory = context.PowerPlant_SubCategory.Where(s => s.ID == MapData.Sub_category).FirstOrDefault();
            if (subcategory == null)
                subcategory = new PowerPlant_SubCategory();

            data.ID = MapData.ID;
            data.Name = MapData.Name;
            data.Latitude = MapData.Latitude;
            data.Logitude = MapData.Longitude;
            data.Details = "<strong>" + MapData.Name + "</strong> </br>" +
                "<hr>" +
                "Country: " + MapData.CountryDesc + "</br>" +
                "Location: " + MapData.Location + "</br>" +
                "Sub-category: " + subcategory.SubCategory_Name + "</br>" +
                "Energy Source/Fuel Type: " + MapData.Energy_Source_Fuel_Type + "</br>" +
                "Power Rating: " + MapData.Power_Rating + "</br>" +
                "Establishment: " + MapData.Establishment + "</br>" +
                "<hr>" +
                "<a href='/Pages/Page?pid=" + MapData.DetailsPageAddress + "'>Read More</a>";
            data.Icon = category.Icon ?? "/Content/icon/1.png";
            data.BasicTypeName = category.Category_Name;

            return data;
        }

        public List<string> GetCategories()
        {
            return context.PowerPlant_Category.Select(s => s.Category_Name).ToList();
        }

        public string GetPowerPlantPageContent(int powerPlantId)
        {
            return context.PowerPlant_Main.Where(s => s.ID == powerPlantId).Select(s => s.DetailsPageAddress).FirstOrDefault();
        }
        public string GetItemPageContent(int itemId)
        {
            return context.PowerPlant_Child.Where(s => s.ID == itemId).Select(s => s.DetailsPageAddress).FirstOrDefault();
        }

        public PowerPlant_Main GetPowerPlant(int powerPlantId)
        {
            return context.PowerPlant_Main.Where(s => s.ID == powerPlantId).FirstOrDefault();
        }

        public PowerPlant_Child GetItem(int itemId)
        {
            return context.PowerPlant_Child.Where(s => s.ID == itemId).FirstOrDefault();
        }

        public PowerPlant_Main GetPowerPlant(string detailsPageId)
        {
            return context.PowerPlant_Main.Where(s => s.DetailsPageAddress == detailsPageId).FirstOrDefault();
        }

        public PowerPlant_Child GetItem(string detailsPageId)
        {
            return context.PowerPlant_Child.Where(s => s.DetailsPageAddress == detailsPageId).FirstOrDefault();
        }

        public string TableData(bool isPP, int id)
        {
            List<TableModel> tableModels = new List<TableModel>();
            if (isPP)
            {
                List<PowerPlant_TableControl> listPowerPlant_Table = context.PowerPlant_TableControl.Where(s => s.Is_PP == 1 && s.Is_Display == 1).OrderBy(s => s.Display_Order).ToList();
                PowerPlant_Main powerPlant_Main = context.PowerPlant_Main.Where(s => s.ID == id).FirstOrDefault();
                foreach (var item in listPowerPlant_Table)
                {
                    string value = string.Empty;
                    try
                    {
                        value = powerPlant_Main.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Main, null).ToString();
                        if(!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                        {
                            value = GetMetadataValue(value, item.Ref_Table, item.Ref_Column);
                        }

                        if(item.Column_Name_DB == "Renewable_")
                        {
                            value = Convert.ToString((Renewable)(Convert.ToInt32(value)));
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    if (!string.IsNullOrEmpty(value))
                    {
                        TableModel tableModel = new TableModel();
                        tableModel.Group_Name = item.Group_Name;
                        tableModel.Column_Name_DB = item.Column_Name_DB;
                        tableModel.Column_Name_View = item.Column_Name_View;
                        tableModel.Value = value.Replace("\n", "</br>");
                        tableModels.Add(tableModel);
                    }
                }

            }
            else
            {
                List<PowerPlant_TableControl> listPowerPlant_Table = context.PowerPlant_TableControl.Where(s => s.Is_PP == 0 && s.Is_Display == 1).OrderBy(s => s.Display_Order).ToList();
                PowerPlant_Child powerPlant_Child = context.PowerPlant_Child.Where(s => s.ID == id).FirstOrDefault();
                foreach (var item in listPowerPlant_Table)
                {
                    string value = string.Empty;
                    try
                    {
                        value = powerPlant_Child.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Child, null).ToString();
                        if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                        {
                            value = GetMetadataValue(value, item.Ref_Table, item.Ref_Column);
                        }
                        if (item.Column_Name_DB == "Renewable_")
                        {
                            value = Convert.ToString((Renewable)(Convert.ToInt32(value))).Replace("_"," ");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    if (!string.IsNullOrEmpty(value))
                    {
                        TableModel tableModel = new TableModel();
                        tableModel.Group_Name = item.Group_Name;
                        tableModel.Column_Name_DB = item.Column_Name_DB;
                        tableModel.Column_Name_View = item.Column_Name_View;
                        tableModel.Value = value.Replace("\n", "</br>");
                        tableModels.Add(tableModel);
                    }
                }
            }
            return GenerateTable(tableModels);
        }

        private string GetMetadataValue(string key, string tableName, string columnName)
        {
            string sql = "select " + columnName + " from [dbo]." + tableName + " where [ID] ='" + key + "'";
            string value = Global.exec(sql);
            return value;
        }

        public string GenerateTable(List<TableModel> tableModels)
        {
            string TableHTML = "<div class='table-contect' style='background: rgb(250, 250, 250)'>" +
                              "<div class='table-reponsive scrollable' style='overflow-x: scroll; overflow-y: scroll; height: 300px;'> " +
                                "<table class='table table-hover table-striped table-condensed table-scrollable detailsTable' width= '100%'>" +

                                    "<tbody>";

            foreach (var item in tableModels)
            {
                TableHTML += "<tr>" +
                                "<td> " + item.Group_Name + " </td> " +
                                "<td> " +
                                    "<p> " + item.Column_Name_View + " </p> " +

                                "</td> " +

                                "<td> " +
                                    item.Value +
                                "</td> " +

                             "</tr>";
            }

            TableHTML += "			</tbody>" +
                        "		</table>" +
                        "	</div>" +
                        "</div>";

            return TableHTML;
        }

        public string GetPowerPlantComparison(string pp1, string pp2, string pp3, string pp4)
        {
            try
            {
                List<TableComaprisonModel> tableModels = new List<TableComaprisonModel>();
                List<PowerPlant_TableControl> listPowerPlant_Table = context.PowerPlant_TableControl.Where(s => s.Is_PP == 1 && s.Is_Display == 1).OrderBy(s => s.Display_Order).ToList();
                PowerPlant_Main powerPlant_Main1 = context.PowerPlant_Main.Where(s => s.Name == pp1).FirstOrDefault();
                PowerPlant_Main powerPlant_Main2 = context.PowerPlant_Main.Where(s => s.Name == pp2).FirstOrDefault();
                PowerPlant_Main powerPlant_Main3 = context.PowerPlant_Main.Where(s => s.Name == pp3).FirstOrDefault();
                PowerPlant_Main powerPlant_Main4 = context.PowerPlant_Main.Where(s => s.Name == pp4).FirstOrDefault();

                foreach (var item in listPowerPlant_Table)
                {
                    string value1 = string.Empty;
                    string value2 = string.Empty;
                    string value3 = string.Empty;
                    string value4 = string.Empty;

                    try
                    {
                        value1 = powerPlant_Main1.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Main1, null).ToString();
                        if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                        {
                            value1 = GetMetadataValue(value1, item.Ref_Table, item.Ref_Column);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    if (powerPlant_Main2 != null)
                    {
                        try
                        {
                            value2 = powerPlant_Main2.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Main2, null).ToString();
                            if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                            {
                                value2 = GetMetadataValue(value2, item.Ref_Table, item.Ref_Column);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (powerPlant_Main3 != null)
                    {
                        try
                        {
                            value3 = powerPlant_Main3.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Main3, null).ToString();
                            if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                            {
                                value2 = GetMetadataValue(value2, item.Ref_Table, item.Ref_Column);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (powerPlant_Main4 != null)
                    {
                        try
                        {
                            value4 = powerPlant_Main4.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Main4, null).ToString();
                            if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                            {
                                value4 = GetMetadataValue(value4, item.Ref_Table, item.Ref_Column);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    if (!string.IsNullOrEmpty(value1))
                    {
                        TableComaprisonModel tableModel = new TableComaprisonModel();
                        tableModel.Group_Name = item.Group_Name;
                        tableModel.Column_Name_DB = item.Column_Name_DB;
                        tableModel.Column_Name_View = item.Column_Name_View;
                        tableModel.Value = value1.Replace("\n", "</br>");
                        tableModel.Value2 = value2.Replace("\n", "</br>");
                        tableModel.Value3 = value3.Replace("\n", "</br>");
                        tableModel.Value4 = value4.Replace("\n", "</br>");
                        tableModels.Add(tableModel);
                    }
                }
                return GenerateComparisonTable(tableModels);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetItemComparison(string pp1, string pp2, string pp3, string pp4)
        {
            try
            {
                List<TableComaprisonModel> tableModels = new List<TableComaprisonModel>();
                List<PowerPlant_TableControl> listPowerPlant_Table = context.PowerPlant_TableControl.Where(s => s.Is_PP == 0 && s.Is_Display == 1).OrderBy(s => s.Display_Order).ToList();
                PowerPlant_Child powerPlant_Child1 = context.PowerPlant_Child.Where(s => s.Model == pp1).FirstOrDefault();
                PowerPlant_Child powerPlant_Child2 = context.PowerPlant_Child.Where(s => s.Model == pp2).FirstOrDefault();
                PowerPlant_Child powerPlant_Child3 = context.PowerPlant_Child.Where(s => s.Model == pp3).FirstOrDefault();
                PowerPlant_Child powerPlant_Child4 = context.PowerPlant_Child.Where(s => s.Model == pp4).FirstOrDefault();

                foreach (var item in listPowerPlant_Table)
                {
                    string value1 = string.Empty;
                    string value2 = string.Empty;
                    string value3 = string.Empty;
                    string value4 = string.Empty;
                    try
                    {
                        value1 = powerPlant_Child1.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Child1, null).ToString();
                        if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                        {
                            value1 = GetMetadataValue(value1, item.Ref_Table, item.Ref_Column);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    if (powerPlant_Child2 != null)
                    {
                        try
                        {
                            value2 = powerPlant_Child2.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Child2, null).ToString();
                            if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                            {
                                value2 = GetMetadataValue(value2, item.Ref_Table, item.Ref_Column);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (powerPlant_Child3 != null)
                    {
                        try
                        {
                            value3 = powerPlant_Child3.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Child3, null).ToString();
                            if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                            {
                                value3 = GetMetadataValue(value3, item.Ref_Table, item.Ref_Column);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (powerPlant_Child4 != null)
                    {
                        try
                        {
                            value4 = powerPlant_Child4.GetType().GetProperty(item.Column_Name_DB).GetValue(powerPlant_Child4, null).ToString();
                            if (!string.IsNullOrEmpty(item.Ref_Table) && !string.IsNullOrEmpty(item.Ref_Column))
                            {
                                value4 = GetMetadataValue(value4, item.Ref_Table, item.Ref_Column);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    if (!string.IsNullOrEmpty(value1))
                    {
                        TableComaprisonModel tableModel = new TableComaprisonModel();
                        tableModel.Group_Name = item.Group_Name;
                        tableModel.Column_Name_DB = item.Column_Name_DB;
                        tableModel.Column_Name_View = item.Column_Name_View;
                        tableModel.Value = value1;
                        tableModel.Value2 = value2;
                        tableModel.Value3 = value3;
                        tableModel.Value4 = value4;
                        tableModels.Add(tableModel);
                    }
                }
                return GenerateComparisonTable(tableModels);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GenerateComparisonTable(List<TableComaprisonModel> tableModels)
        {
            string TableHTML = "<div class='table-contect' style='background: rgb(250, 250, 250)'>" +
                              "<div class='table-reponsive scrollable' style='overflow-x: scroll; overflow-y: scroll; height: 300px;'> " +
                                "<table class='table table-hover table-striped table-condensed table-scrollable compareTable' width= '100%'>" +

                                    "<tbody>";

            foreach (var item in tableModels)
            {
                TableHTML += "<tr>" +
                                "<td> " + item.Group_Name + " </td> " +
                                "<td> " +
                                    "<p> " + item.Column_Name_View + " </p> " +

                                "</td> " +

                                "<td> " +
                                    item.Value +
                                "</td> " +
                                "<td> " +
                                    item.Value2 +
                                "</td> " +
                                "<td> " +
                                    item.Value3 +
                                "</td> " +
                                "<td> " +
                                    item.Value4 +
                                "</td> " +

                             "</tr>";
            }

            TableHTML += "			</tbody>" +
                        "		</table>" +
                        "	</div>" +
                        "</div>";

            return TableHTML;
        }
        public List<PowerPlantSearchModel> GetPowerPlantListFilter(string name)
        {
            List<PowerPlantSearchModel> ppListModel = new List<PowerPlantSearchModel>();

            var ppList = context.PowerPlant_Main.Where(s => s.Name.StartsWith(name)).ToList();

            foreach (var item in ppList)
            {
                PowerPlantSearchModel pp = new PowerPlantSearchModel();
                pp.ID = item.ID;
                pp.Name = item.Name;

                ppListModel.Add(pp);
            }

            return ppListModel;
        }

        public List<PowerPlantSearchModel> GetItemListFilter(string name)
        {
            List<PowerPlantSearchModel> mListModel = new List<PowerPlantSearchModel>();

            var ppList = context.PowerPlant_Child.Where(s => s.Model.StartsWith(name)).ToList();

            foreach (var item in ppList)
            {
                PowerPlantSearchModel pp = new PowerPlantSearchModel();
                pp.ID = item.ID;
                pp.Name = item.Model;

                mListModel.Add(pp);
            }

            return mListModel;
        }

        public List<PowerPlantSearchModel> GetAllListFilter(string name)
        {
            List<PowerPlantSearchModel> ppListModel = new List<PowerPlantSearchModel>();

            List<PowerPlant_Main> ppList = new List<PowerPlant_Main>();

            List<PowerPlant_Child> ppItemList = new List<PowerPlant_Child>();

            #region name
            ppList = context.PowerPlant_Main.Where(s => s.Name.StartsWith(name) || s.Short_Description.Contains(name)).ToList();
            ppItemList = context.PowerPlant_Child.Where(s => s.Model.StartsWith(name) || s.Basic_Description.Contains(name)).ToList();

            foreach (var item in ppList)
            {
                PowerPlantSearchModel pp = new PowerPlantSearchModel();
                pp.ID = item.ID;
                pp.Name = item.Name;

                ppListModel.Add(pp);
            }

            foreach (var item in ppItemList)
            {
                PowerPlantSearchModel pp = new PowerPlantSearchModel();
                pp.ID = item.ID;
                pp.Name = item.Model;

                ppListModel.Add(pp);
            }
            #endregion

            return ppListModel;
        }
    }

}