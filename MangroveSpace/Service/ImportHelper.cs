using MangroveSpace;
using MapProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MapProject.Service
{
    public class ImportHelper
    {
        public string GeneralDataImport(DataTable dt, string user)
        {
            int i = 0;
            try
            {
                using (MangroveSpaceEntities entity = new MangroveSpaceEntities())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        GenericTable<PowerPlant_Main> genericTable = new GenericTable<PowerPlant_Main>();
                        string name = row["Name"].ToString();
                        if (!string.IsNullOrEmpty(name))
                        {
                            PowerPlant_Main ppMain = entity.PowerPlant_Main.Where(s => s.Name == name).FirstOrDefault();

                            if (ppMain == null)
                            {
                                ppMain = new PowerPlant_Main();
                                ppMain = genericTable.SetMultiProp(row, ppMain);
                                if (entity.PowerPlant_Main.Count() == 0)
                                {
                                    ppMain.ID = 1;
                                }
                                else
                                {
                                    ppMain.ID = entity.PowerPlant_Main.Max(s => s.ID) + 1;
                                }
                                ppMain.EntryBy = user;
                                ppMain.EntryDate = DateTime.Now;
                                entity.PowerPlant_Main.Add(ppMain);

                                ppMain.DetailsPageAddress = CreatePage(ppMain.Name, user, "PP");
                            }
                            else
                            {
                                ppMain = genericTable.SetMultiProp(row, ppMain);
                                ppMain.ModifyBy = user;
                                ppMain.ModifyDate = DateTime.Now;
                            }
                            entity.SaveChanges();
                            i++;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Successfully Imported " + i.ToString() + " Data";
        }

        public string TechnicalDataImport(DataTable dt, string user)
        {
            int i = 0;
            try
            {
                using (MangroveSpaceEntities entity = new MangroveSpaceEntities())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        GenericTable<PowerPlant_Child> genericTable = new GenericTable<PowerPlant_Child>();
                        string model = row["Model"].ToString();
                        if (!string.IsNullOrEmpty(model))
                        {
                            PowerPlant_Child ppChild = entity.PowerPlant_Child.Where(s => s.Model == model).FirstOrDefault();
                            if (ppChild == null)
                            {
                                ppChild = new PowerPlant_Child();
                                ppChild = genericTable.SetMultiProp(row, ppChild);

                                if (entity.PowerPlant_Child.Count() == 0)
                                {
                                    ppChild.ID = 1;
                                }
                                else
                                {
                                    ppChild.ID = entity.PowerPlant_Child.Max(s => s.ID) + 1;
                                }
                                ppChild.EntryBy = user;
                                ppChild.EntryDate = DateTime.Now;
                                entity.PowerPlant_Child.Add(ppChild);

                                ppChild.DetailsPageAddress = CreatePage(ppChild.Model, user, "M");
                            }
                            else
                            {
                                ppChild = genericTable.SetMultiProp(row, ppChild);
                                ppChild.ModifyBy = user;
                                ppChild.ModifyDate = DateTime.Now;
                            }

                            entity.SaveChanges();
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Successfully Imported " + i.ToString() + " Data";
        }

        

        private string CreatePage(string pageTitle, string userId, string tag)
        {
            using (MangroveSpaceEntities entity = new MangroveSpaceEntities())
            {
                AspCMSPage aspCMSPages = new AspCMSPage();
                if (entity.PowerPlant_Main.Count() == 0)
                {
                    aspCMSPages.ID = 1;
                }
                else
                {
                    aspCMSPages.ID = entity.AspCMSPages.Max(s => s.ID) + 1;
                }

                int count = 0;
                string PageID = Convert.ToString(pageTitle);
                PageID = PageID.Replace(" ", "");

            Ck:
                int ck_name = Global.exec("select count(*) from AspCMSPage where PageID ='" + PageID + "'", 0);
                if (ck_name != 0)
                {
                    count++;
                    PageID = PageID + Convert.ToString(count);
                    goto Ck;
                }

                aspCMSPages.PageID = pageTitle.Replace(" ", "");
                aspCMSPages.PageTitle = pageTitle;
                aspCMSPages.PageLanguage = "EN";
                aspCMSPages.PageTamplateID = "2";
                aspCMSPages.TAG = tag;
                aspCMSPages.PageBody = "<p>[Table]</p>";
                aspCMSPages.EntryBy = userId;
                aspCMSPages.EntryDate = DateTime.Now;
                aspCMSPages.Aproved = true;
                aspCMSPages.ApprovedBy = userId;
                entity.AspCMSPages.Add(aspCMSPages);
                entity.SaveChanges();

                return aspCMSPages.PageID;
            }
        }
    }

    class GenericTable<T>
    {
        public T SetMultiProp(DataRow dr, T obj)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                string name = typeof(T).FullName;

                if (prop == props[0])
                {

                }

                if (name.Contains("PowerPlant_Main"))
                {
                    if (prop.Name == "Country")
                    {
                        dynamic value = dr.IsNull("Country") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Country] where [Country_Name] ='" + dr["Country"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Scale_Size")
                    {
                        dynamic value = dr.IsNull("Scale_Size") ? (int?)null : Global.exec("select[ID] from[dbo].[PowerPlant_Level] where Tag = 1 and Value =  '" + dr["Scale_Size"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Frequency__Hz_")
                    {
                        dynamic value = dr.IsNull("Frequency__Hz_") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Freq] where [Value] ='" + dr["Frequency__Hz_"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Renewable_")
                    {
                        dynamic value = dr.IsNull("Renewable_") ? (int?)null : (int?)(Renewable)Enum.Parse(typeof(Renewable), dr["Renewable_"].ToString().Replace(" ", "_"), true);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Energy_Source_Fuel_Type")
                    {
                        dynamic value = dr.IsNull("Energy_Source_Fuel_Type") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_FuelType] where [Value] ='" + dr["Energy_Source_Fuel_Type"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Basic_Category")
                    {
                        dynamic value = dr.IsNull("Basic_Category") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Category] where [Category_Name] ='" + dr["Basic_Category"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Sub_category")
                    {
                        dynamic value = dr.IsNull("Sub_category") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_SubCategory] where [SubCategory_Name] ='" + dr["Sub_category"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else
                    {
                        try
                        {
                            dynamic value = obj.GetType().GetProperty(prop.Name.ToString()).GetValue(obj, null);
                            Type type = prop.PropertyType;

                            if (type == typeof(string))
                            {
                                string temp = Convert.ToString(value);
                                try
                                {
                                    value = Convert.ToString(dr[prop.Name]);
                                    prop.SetValue(obj, value, null);
                                }
                                catch
                                {

                                }

                            }
                            else if (type == typeof(Int32) || type == typeof(Int32?))
                            {
                                int temp2 = Convert.ToInt32(value);
                                if (temp2 == 0)
                                {
                                    try
                                    {
                                        value = Convert.ToInt32(dr[prop.Name]);
                                        prop.SetValue(obj, value, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            value = Convert.ToInt32(Convert.ToDecimal(dr[prop.Name]));
                                            prop.SetValue(obj, value, null);
                                        }
                                        catch (Exception e)
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {

                                        prop.SetValue(obj, temp2, null);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }

                            else if (type == typeof(Decimal) || type == typeof(Decimal?))
                            {
                                decimal temp3 = Convert.ToDecimal(value);
                                if (temp3 == 0)
                                {
                                    try
                                    {
                                        value = Convert.ToDecimal(dr[prop.Name]);
                                        prop.SetValue(obj, value, null);
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {

                                        prop.SetValue(obj, temp3, null);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }


                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                else if (name.Contains("PowerPlant_Child"))
                {
                    if (prop.Name == "Item_name")
                    {
                        dynamic value = dr.IsNull("Item_name") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_ChildItem] where [Value] ='" + dr["Item_name"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Popularity_Rating_Level")
                    {
                        dynamic value = dr.IsNull("Popularity_Rating_Level") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 2 and Value = '" + dr["Popularity_Rating_Level"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Price_Cost")
                    {
                        dynamic value = dr.IsNull("Price_Cost") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 2 and Value = '" + dr["Price_Cost"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Size_Capacity")
                    {
                        dynamic value = dr.IsNull("Size_Capacity") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 1 and Value = '" + dr["Size_Capacity"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Country")
                    {
                        dynamic value = dr.IsNull("Country") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Country] where [Country_Name] ='" + dr["Country"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Fuel_Type_Energy_Source")
                    {
                        dynamic value = dr.IsNull("Fuel_Type_Energy_Source") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_ChildFuelType] where '" + dr["Fuel_Type_Energy_Source"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Speed_Velocity_Level")
                    {
                        dynamic value = dr.IsNull("Speed_Velocity_Level") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 2 and Value = '" + dr["Speed_Velocity_Level"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Control")
                    {
                        dynamic value = dr.IsNull("Control") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 3 and Value = '" + dr["Control"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Noise_Level")
                    {
                        dynamic value = dr.IsNull("Noise_Level") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 3 and Value = '" + dr["Noise_Level"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Buy_Sale_Amount_Level")
                    {
                        dynamic value = dr.IsNull("Buy_Sale_Amount_Level") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 2 and Value = '" + dr["Buy_Sale_Amount_Level"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Type_of_Magnet")
                    {
                        dynamic value = dr.IsNull("Type_of_Magnet") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_MagnetType] where Value = '" + dr["Type_of_Magnet"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Remanence_Level")
                    {
                        dynamic value = dr.IsNull("Remanence_Level") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 2 and Value = '" + dr["Remanence_Level"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Type_of_Core")
                    {
                        dynamic value = dr.IsNull("Type_of_Core") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_CoreType] where Value ='" + dr["Type_of_Core"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Magnetic_Saturation_Level")
                    {
                        dynamic value = dr.IsNull("Magnetic_Saturation_Level") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 2 and Value = '" + dr["Magnetic_Saturation_Level"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Core_Loss")
                    {
                        dynamic value = dr.IsNull("Core_Loss") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Level] where Tag = 2 and Value = '" + dr["Core_Loss"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else if (prop.Name == "Company_Manufacturer")
                    {
                        dynamic value = dr.IsNull("Company_Manufacturer") ? (int?)null : Global.exec("select [ID] from [dbo].[PowerPlant_Company] where Value = '" + dr["Company_Manufacturer"] + "'", 0);
                        prop.SetValue(obj, value, null);
                    }
                    else
                    {
                        try
                        {
                            dynamic value = obj.GetType().GetProperty(prop.Name.ToString()).GetValue(obj, null);
                            Type type = prop.PropertyType;

                            if (type == typeof(string))
                            {
                                string temp = Convert.ToString(value);
                                try
                                {
                                    value = Convert.ToString(dr[prop.Name]);
                                    prop.SetValue(obj, value, null);
                                }
                                catch
                                {

                                }

                            }
                            else if (type == typeof(Int32) || type == typeof(Int32?))
                            {
                                int temp2 = Convert.ToInt32(value);
                                if (temp2 == 0)
                                {
                                    try
                                    {
                                        value = Convert.ToInt32(dr[prop.Name]);
                                        prop.SetValue(obj, value, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            value = Convert.ToInt32(Convert.ToDecimal(dr[prop.Name]));
                                            prop.SetValue(obj, value, null);
                                        }
                                        catch (Exception e)
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {

                                        prop.SetValue(obj, temp2, null);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }

                            else if (type == typeof(Decimal) || type == typeof(Decimal?))
                            {
                                decimal temp3 = Convert.ToDecimal(value);
                                if (temp3 == 0)
                                {
                                    try
                                    {
                                        value = Convert.ToDecimal(dr[prop.Name]);
                                        prop.SetValue(obj, value, null);
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {

                                        prop.SetValue(obj, temp3, null);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }


                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                
                

            }

            return obj;
        }
    }
}