using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace MangroveSpace
{
    public class MvcApplication : System.Web.HttpApplication
    {

        string ActiveServerName;
        string ActiveUserName;
        string ActivePassword;
        string ActiveDatabse;
        string ActiveString;
        string AppName;
        string CopyRight;
        string AreaName;
        string FrontTheme;
        string BackTheme;

        public void LoadConfigINI()
        {
            List<string> stringlist = new List<string>();
            string fileName = Path.Combine(Server.MapPath("~/Config.ini"));
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {

                    stringlist.Add(line);
                }

            }
            ActiveServerName = stringlist[0].Split('=').LastOrDefault().Trim();
            ActiveUserName = stringlist[1].Split('=').LastOrDefault().Trim();
            ActivePassword = stringlist[2].Split('=').LastOrDefault().Trim();
            ActiveDatabse = stringlist[3].Split('=').LastOrDefault().Trim();
            ActiveString = stringlist[4].Split('=').LastOrDefault().Trim();
            AppName = stringlist[5].Split('=').LastOrDefault().Trim();
            CopyRight = stringlist[6].Split('=').LastOrDefault().Trim();
            AreaName = stringlist[7].Split('=').LastOrDefault().Trim();
            FrontTheme = stringlist[8].Split('=').LastOrDefault().Trim();
            BackTheme = stringlist[9].Split('=').LastOrDefault().Trim();

        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LoadConfigINI();

            string DefaultConnection = "server=" + ActiveServerName + ";uid=" + ActiveUserName + ";pwd=" + ActivePassword + ";database=" + ActiveDatabse;
            string MangroveSpaceEntities = "metadata=res://*/MangroveSpaceModel.csdl|res://*/MangroveSpaceModel.ssdl|res://*/MangroveSpaceModel.msl;provider=System.Data.SqlClient;provider connection string=\"Data Source=" + ActiveServerName + ";Initial Catalog=" + ActiveDatabse + ";user id=" + ActiveUserName + ";password=" + ActivePassword + ";MultipleActiveResultSets=True;App=EntityFramework\"";

            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");

            string con;
            con = section.ConnectionStrings["DefaultConnection"].ConnectionString;


            if (con != DefaultConnection)
            {
                section.ConnectionStrings["DefaultConnection"].ConnectionString = DefaultConnection;

                var EduCare_Entitie = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
                EduCare_Entitie.ConnectionStrings["MangroveSpaceEntities"].ConnectionString = MangroveSpaceEntities;

                configuration.Save();
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            LoadConfigINI();
            this.Session["UserRole"] = Global.exec("SELECT ur.[RoleId] FROM [dbo].[AspNetUsers] u INNER JOIN [dbo].[AspNetUserRoles] ur ON u.[Id] = ur.[UserId] WHERE u.[UserName] = '" + User.Identity.GetUserName().ToString() + "'; ");
            this.Session["IDate"] = DateTime.Now.ToString("M/d/yyyy");
            this.Session["AppName"] = AppName;
            this.Session["CopyRight"] = CopyRight;
            this.Session["CopyRightAddress"] = "#";
            this.Session["TopHeader"] = ActiveString;
            this.Session["Title"] = ActiveString;
            this.Session["DBName"] = ActiveDatabse;


            this.Session["Version"] = "1.0.0";
            this.Session["Year"] = "2018";
            this.Session["PCID"] = "webentry";
            this.Session["SubSectorID"] = 1;

            this.Session["Category"] = 0;

            this.Session["Lang"] = "EN";

            this.Session["CurrentPage"] = "";
            this.Session["BackTheme"] = "~/Views/Shared/" + BackTheme + "/";

            this.Session["Area"] = "";



            string areas = AreaName;
            string areaspath = "";
            if (areas != "")
            {

                this.Session["Areas"] = areas;
                areaspath = "Areas/" + areas + "/";

                this.Session["AdminTheme"] = "~/" + areaspath + "Views/Shared/admin/";
                this.Session["MainThemeContent"] = "/assets/admin";
                this.Session["FrontTheme"] = "~/" + areaspath + "Views/Shared/" + FrontTheme + "/";
                this.Session["ThemeName"] = FrontTheme;

            }
            else
            {
                this.Session["Areas"] = "";
                areaspath = "";

                this.Session["AdminTheme"] = "~/Views/Shared/admin/";
                this.Session["MainThemeContent"] = "/assets/admin";
                this.Session["FrontTheme"] = "~/Views/Shared/" + FrontTheme + "/";
                this.Session["ThemeName"] = FrontTheme;
            }





            try
            {
                HttpBrowserCapabilities myBrowser = new HttpBrowserCapabilities();
                myBrowser = Request.Browser;

                string LoginUser = Request.ServerVariables["LOGON_USER"];
                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string remothost = Request.ServerVariables["REMOTE_HOST"];
                string reqmethod = Request.ServerVariables["REQUEST_METHOD"];
                string platform = myBrowser.Platform;
                string language = Request.ServerVariables["http_accept_language"];
                string page = Request.ServerVariables["HTTP_REFERER"];
                string agent = Request.ServerVariables["HTTP_USER_AGENT"];
                string url = "http://ip-api.com/json/"+ip;
                



                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
                webReq.Method = "GET";
                HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();
                var dataStream = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                var obj = js.Deserialize<dynamic>(responseFromServer);
                string location = obj["city"] + "," + obj["country"];

                string sql = @"insert into [dbo].[AspCMSAnalytics] (LoginUser, RemoteIP, RemoteHost, ReqMethod, [Platform], BrowserLan, BrowserType, UserID,Location) 
                           values ('" + LoginUser + "','" + ip + "', '" + remothost + "','" + reqmethod + "','" + platform + "','" + language + "','" + agent + "','000','" + location + "')";

                Global.exec(sql);
                

            }
            catch (Exception ex) { }

        }
    }

    public static class Global
    {
       
        public static IEnumerable<dynamic> Sql(this DbContext db, string Sql)
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

        


        public static DataTable ReadData(string SqlString)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connetionString);

            try
            {
                connection.Open();
                adapter.SelectCommand = new SqlCommand(SqlString, connection);
                adapter.Fill(ds);
                connection.Close();
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        internal static object Sql(object db, string str)
        {
            throw new NotImplementedException();
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

        public static int exec(string sql, int i)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            try
            { return db.Database.SqlQuery<int>(sql).Single(); }
            catch (Exception) { return 0; }
        }

        public static int execInt(string sql)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            try
            { return db.Database.SqlQuery<int>(sql).Single(); }
            catch (Exception) { return 0; }
        }

        public static string GetSettingValue(string SName)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            try
            { return db.Database.SqlQuery<string>("select top 1 [SettingValue] from [dbo].[AspSysSetting] where [SettingName] = '" + SName + "'").Single(); }
            catch (Exception) { return ""; }
        }


        public static Boolean execBool(string sql)
        {
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            try
            { return db.Database.SqlQuery<Boolean>(sql).Single(); }
            catch (Exception) { return false; }
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


        private static readonly Dictionary<string, string> MIMETypesDictionary = new Dictionary<string, string>
  {
    {"ai", "application/postscript"},
    {"aif", "audio/x-aiff"},
    {"aifc", "audio/x-aiff"},
    {"aiff", "audio/x-aiff"},
    {"asc", "text/plain"},
    {"atom", "application/atom+xml"},
    {"au", "audio/basic"},
    {"avi", "video/x-msvideo"},
    {"bcpio", "application/x-bcpio"},
    {"bin", "application/octet-stream"},
    {"bmp", "image/bmp"},
    {"cdf", "application/x-netcdf"},
    {"cgm", "image/cgm"},
    {"class", "application/octet-stream"},
    {"cpio", "application/x-cpio"},
    {"cpt", "application/mac-compactpro"},
    {"csh", "application/x-csh"},
    {"css", "text/css"},
    {"dcr", "application/x-director"},
    {"dif", "video/x-dv"},
    {"dir", "application/x-director"},
    {"djv", "image/vnd.djvu"},
    {"djvu", "image/vnd.djvu"},
    {"dll", "application/octet-stream"},
    {"dmg", "application/octet-stream"},
    {"dms", "application/octet-stream"},
    {"doc", "application/msword"},
    {"docx","application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
    {"dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
    {"docm","application/vnd.ms-word.document.macroEnabled.12"},
    {"dotm","application/vnd.ms-word.template.macroEnabled.12"},
    {"dtd", "application/xml-dtd"},
    {"dv", "video/x-dv"},
    {"dvi", "application/x-dvi"},
    {"dxr", "application/x-director"},
    {"eps", "application/postscript"},
    {"etx", "text/x-setext"},
    {"exe", "application/octet-stream"},
    {"ez", "application/andrew-inset"},
    {"gif", "image/gif"},
    {"gram", "application/srgs"},
    {"grxml", "application/srgs+xml"},
    {"gtar", "application/x-gtar"},
    {"hdf", "application/x-hdf"},
    {"hqx", "application/mac-binhex40"},
    {"htm", "text/html"},
    {"html", "text/html"},
    {"ice", "x-conference/x-cooltalk"},
    {"ico", "image/x-icon"},
    {"ics", "text/calendar"},
    {"ief", "image/ief"},
    {"ifb", "text/calendar"},
    {"iges", "model/iges"},
    {"igs", "model/iges"},
    {"jnlp", "application/x-java-jnlp-file"},
    {"jp2", "image/jp2"},
    {"jpe", "image/jpeg"},
    {"jpeg", "image/jpeg"},
    {"jpg", "image/jpeg"},
    {"js", "application/x-javascript"},
    {"kar", "audio/midi"},
    {"latex", "application/x-latex"},
    {"lha", "application/octet-stream"},
    {"lzh", "application/octet-stream"},
    {"m3u", "audio/x-mpegurl"},
    {"m4a", "audio/mp4a-latm"},
    {"m4b", "audio/mp4a-latm"},
    {"m4p", "audio/mp4a-latm"},
    {"m4u", "video/vnd.mpegurl"},
    {"m4v", "video/x-m4v"},
    {"mac", "image/x-macpaint"},
    {"man", "application/x-troff-man"},
    {"mathml", "application/mathml+xml"},
    {"me", "application/x-troff-me"},
    {"mesh", "model/mesh"},
    {"mid", "audio/midi"},
    {"midi", "audio/midi"},
    {"mif", "application/vnd.mif"},
    {"mov", "video/quicktime"},
    {"movie", "video/x-sgi-movie"},
    {"mp2", "audio/mpeg"},
    {"mp3", "audio/mpeg"},
    {"mp4", "video/mp4"},
    {"mpe", "video/mpeg"},
    {"mpeg", "video/mpeg"},
    {"mpg", "video/mpeg"},
    {"mpga", "audio/mpeg"},
    {"ms", "application/x-troff-ms"},
    {"msh", "model/mesh"},
    {"mxu", "video/vnd.mpegurl"},
    {"nc", "application/x-netcdf"},
    {"oda", "application/oda"},
    {"ogg", "application/ogg"},
    {"pbm", "image/x-portable-bitmap"},
    {"pct", "image/pict"},
    {"pdb", "chemical/x-pdb"},
    {"pdf", "application/pdf"},
    {"pgm", "image/x-portable-graymap"},
    {"pgn", "application/x-chess-pgn"},
    {"pic", "image/pict"},
    {"pict", "image/pict"},
    {"png", "image/png"},
    {"pnm", "image/x-portable-anymap"},
    {"pnt", "image/x-macpaint"},
    {"pntg", "image/x-macpaint"},
    {"ppm", "image/x-portable-pixmap"},
    {"ppt", "application/vnd.ms-powerpoint"},
    {"pptx","application/vnd.openxmlformats-officedocument.presentationml.presentation"},
    {"potx","application/vnd.openxmlformats-officedocument.presentationml.template"},
    {"ppsx","application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
    {"ppam","application/vnd.ms-powerpoint.addin.macroEnabled.12"},
    {"pptm","application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
    {"potm","application/vnd.ms-powerpoint.template.macroEnabled.12"},
    {"ppsm","application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
    {"ps", "application/postscript"},
    {"qt", "video/quicktime"},
    {"qti", "image/x-quicktime"},
    {"qtif", "image/x-quicktime"},
    {"ra", "audio/x-pn-realaudio"},
    {"ram", "audio/x-pn-realaudio"},
    {"ras", "image/x-cmu-raster"},
    {"rdf", "application/rdf+xml"},
    {"rgb", "image/x-rgb"},
    {"rm", "application/vnd.rn-realmedia"},
    {"roff", "application/x-troff"},
    {"rtf", "text/rtf"},
    {"rtx", "text/richtext"},
    {"sgm", "text/sgml"},
    {"sgml", "text/sgml"},
    {"sh", "application/x-sh"},
    {"shar", "application/x-shar"},
    {"silo", "model/mesh"},
    {"sit", "application/x-stuffit"},
    {"skd", "application/x-koan"},
    {"skm", "application/x-koan"},
    {"skp", "application/x-koan"},
    {"skt", "application/x-koan"},
    {"smi", "application/smil"},
    {"smil", "application/smil"},
    {"snd", "audio/basic"},
    {"so", "application/octet-stream"},
    {"spl", "application/x-futuresplash"},
    {"src", "application/x-wais-source"},
    {"sv4cpio", "application/x-sv4cpio"},
    {"sv4crc", "application/x-sv4crc"},
    {"svg", "image/svg+xml"},
    {"swf", "application/x-shockwave-flash"},
    {"t", "application/x-troff"},
    {"tar", "application/x-tar"},
    {"tcl", "application/x-tcl"},
    {"tex", "application/x-tex"},
    {"texi", "application/x-texinfo"},
    {"texinfo", "application/x-texinfo"},
    {"tif", "image/tiff"},
    {"tiff", "image/tiff"},
    {"tr", "application/x-troff"},
    {"tsv", "text/tab-separated-values"},
    {"txt", "text/plain"},
    {"ustar", "application/x-ustar"},
    {"vcd", "application/x-cdlink"},
    {"vrml", "model/vrml"},
    {"vxml", "application/voicexml+xml"},
    {"wav", "audio/x-wav"},
    {"wbmp", "image/vnd.wap.wbmp"},
    {"wbmxl", "application/vnd.wap.wbxml"},
    {"wml", "text/vnd.wap.wml"},
    {"wmlc", "application/vnd.wap.wmlc"},
    {"wmls", "text/vnd.wap.wmlscript"},
    {"wmlsc", "application/vnd.wap.wmlscriptc"},
    {"wrl", "model/vrml"},
    {"xbm", "image/x-xbitmap"},
    {"xht", "application/xhtml+xml"},
    {"xhtml", "application/xhtml+xml"},
    {"xls", "application/vnd.ms-excel"},
    {"xml", "application/xml"},
    {"xpm", "image/x-xpixmap"},
    {"xsl", "application/xml"},
    {"xlsx","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
    {"xltx","application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
    {"xlsm","application/vnd.ms-excel.sheet.macroEnabled.12"},
    {"xltm","application/vnd.ms-excel.template.macroEnabled.12"},
    {"xlam","application/vnd.ms-excel.addin.macroEnabled.12"},
    {"xlsb","application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
    {"xslt", "application/xslt+xml"},
    {"xul", "application/vnd.mozilla.xul+xml"},
    {"xwd", "image/x-xwindowdump"},
    {"xyz", "chemical/x-xyz"},
    {"zip", "application/zip"}
  };

        public static string GetMIMEType(string fileName)
        {
            //get file extension
            string extension = Path.GetExtension(fileName).ToLowerInvariant();

            if (extension.Length > 0 &&
                MIMETypesDictionary.ContainsKey(extension.Remove(0, 1)))
            {
                return MIMETypesDictionary[extension.Remove(0, 1)];
            }
            return "unknown/unknown";
        }

    }

}
