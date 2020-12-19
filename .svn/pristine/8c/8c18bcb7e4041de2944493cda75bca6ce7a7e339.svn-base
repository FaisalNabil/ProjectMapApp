using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MangroveSpace
{
    public static class GlobalMethod
    {
        public static string OrdInvoiceNumber()
        {
            string ordno = "";
            ordno = "Or" + DateTime.Now.ToString("yyMMddhhmmss.fff");
            return ordno;
        }

        public static void AddOrder(string PRID, double QTY, double Rate, double Disc)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            DataTable dt = (DataTable)HttpContext.Current.Session["ProductAdd"];
            DataRow[] rowsno;
            rowsno = dt.Select();
            int rownumber = rowsno.Length;
            var ProductName = db.Database.SqlQuery<string>("select Brand + ' ' + BrandInfo from dbo.ProductInfo where ProductID = '" + PRID + "'").Single();


            DataRow row = dt.NewRow();
            row["SN"] = Convert.ToString((rownumber + 1));
            row["PID"] = PRID;
            row["PName"] = ProductName;
            row["Rate"] = Convert.ToString(Rate);
            row["QTY"] = Convert.ToString(QTY);
            row["Discount"] = Convert.ToString(Disc);
            row["Total"] = Convert.ToString((Rate * QTY) - Disc);

            dt.Rows.Add(row);
            HttpContext.Current.Session["ProductAdd"] = dt;
        }

        public static String DashBoard_menu()
        {
            int preorder = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            MangroveSpaceEntities db = new MangroveSpaceEntities();


            List<dynamic> Information = GlobalMethod.ListFromSql(db, "select [MenuID],[MenuType],[MenuName],[MenuDisplayName],[MenuLink],[MenuLinkOption],[MenuOrder],[MenuPrivilege],[MenuPrivilegeOption],[MenuIcon] from [AspSysMenu] where [MenuStatus] = 1 order by [MenuSerial]").ToList();

            foreach (dynamic item in Information)
            {
                if (preorder == 0)
                {
                    sb.AppendLine("<li>");
                    sb.AppendLine("<a><i class='" + item.MenuIcon + "'></i> " + item.MenuDisplayName + " <span class='fa fa-chevron-down'></span></a>");
                    preorder = item.MenuOrder;
                }
                else
                {
                    if (preorder == 1 && item.MenuOrder == 1)
                    {
                        sb.AppendLine("</li>");
                        sb.AppendLine("<li>");
                        sb.AppendLine("<a><i class='" + item.MenuIcon + "'></i> " + item.MenuDisplayName + " <span class='fa fa -chevron-down'></span></a>");
                        preorder = item.MenuOrder;
                    }
                    else if (preorder == 1 && item.MenuOrder == 2)
                    {
                        sb.AppendLine("<ul class='nav child_menu'>");
                        sb.AppendLine("<li><a href='" + "/" + item.MenuLink + "'>" + item.MenuDisplayName + "</a></li>");
                        preorder = item.MenuOrder;
                    }
                    else if (preorder == 2 && item.MenuOrder == 2)
                    {
                        sb.AppendLine("<li><a href='" + "/" + item.MenuLink + "'>" + item.MenuDisplayName + "</a></li>");
                        preorder = item.MenuOrder;
                    }
                    else if (preorder == 2 && item.MenuOrder == 3)
                    {
                        sb.Remove(sb.Length - 9 - 2, 9);
                        sb.AppendLine("<span class='fa fa-chevron-down'></span></a>");
                        sb.AppendLine("<ul class='nav child_menu'>");
                        sb.AppendLine("<li class='sub_menu'><a href='" + "/" + item.MenuLink + "'>" + item.MenuDisplayName + "</a></li>");
                        preorder = item.MenuOrder;
                    }
                    else if (preorder == 3 && item.MenuOrder == 3)
                    {
                        sb.AppendLine("<li class='sub_menu'><a href='" + "/" + item.MenuLink + "'>" + item.MenuDisplayName + "</a></li>");
                        preorder = item.MenuOrder;
                    }
                    else if (preorder == 3 && item.MenuOrder == 2)
                    {
                        sb.AppendLine("</ul>");
                        sb.AppendLine("</li>");
                        sb.AppendLine("<li><a href='" + "/" + item.MenuLink + "'>" + item.MenuDisplayName + "</a></li>");
                        preorder = item.MenuOrder;
                    }
                    else if (preorder == 3 && item.MenuOrder == 1)
                    {
                        sb.AppendLine("</ul>");
                        sb.AppendLine("</li>");
                        sb.AppendLine("</ul>");
                        sb.AppendLine("</li>");
                        sb.AppendLine("<li>");
                        sb.AppendLine("<a><i class='" + item.MenuIcon + "'></i> " + item.MenuDisplayName + " <span class='fa fa-chevron-down'></span></a>");
                        preorder = item.MenuOrder;
                    }
                    else if (preorder == 2 && item.MenuOrder == 1)
                    {
                        sb.AppendLine("</ul>");
                        sb.AppendLine("</li>");
                        sb.AppendLine("<li>");
                        sb.AppendLine("<a><i class='" + item.MenuIcon + "'></i> " + item.MenuDisplayName + " <span class='fa fa-chevron-down'></span></a>");
                        preorder = item.MenuOrder;
                    }
                }
            }

            if (preorder == 3)
            {
                sb.AppendLine("</ul>");
                sb.AppendLine("</li>");
                sb.AppendLine("</ul>");
                sb.AppendLine("</li>");
            }
            else if (preorder == 2)
            {
                sb.AppendLine("</ul>");
                sb.AppendLine("</li>");
            }
            else if (preorder == 1)
            {
                sb.AppendLine("</li>");
            }

            return sb.ToString();
        }

        public static IEnumerable<dynamic> DynamicListFromSql(this DbContext db, string Sql, Dictionary<string, object> Params)
        {
            using (var cmd = db.Database.Connection.CreateCommand())
            {
                cmd.CommandText = Sql;
                if (cmd.Connection.State != ConnectionState.Open) { cmd.Connection.Open(); }

                foreach (KeyValuePair<string, object> p in Params)
                {
                    DbParameter dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = p.Key;
                    dbParameter.Value = p.Value;
                    cmd.Parameters.Add(dbParameter);
                }

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var row = new ExpandoObject() as IDictionary<string, object>;
                        for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                        {
                            row.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
                        }
                        yield return row;
                    }

                    dataReader.Close();

                }
            }
        }



        public static IEnumerable<dynamic> ListFromSql(this DbContext db, string Sql)
        {
            using (var cmd = db.Database.Connection.CreateCommand())
            {
                cmd.CommandText = Sql;
                if (cmd.Connection.State != ConnectionState.Open) { cmd.Connection.Open(); }

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var row = new ExpandoObject() as IDictionary<string, object>;
                        for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                        {
                            row.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
                        }
                        yield return row;
                    }

                    dataReader.Close();

                }
            }
        }

        public static string exec(string sql)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            try
            { return db.Database.SqlQuery<string>(sql).Single(); }
            catch (Exception) { return null; }
        }

        internal static void exec(MangroveSpaceEntities db, object sql)
        {
            throw new NotImplementedException();
        }

        public static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
    }
}