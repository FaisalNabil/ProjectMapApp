using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace
{
    public static class NewsLetterHelper
    {
        public static MvcHtmlString GetShortNewsLetterItem(this HtmlHelper helper)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            MangroveSpaceEntities db = new MangroveSpaceEntities();

            List<dynamic> Information = Global.Sql(db, "select top 3 [ID],[NoticeID],[NoticeName],[NoticeDate],[AttachFile],[NoticeOrderID],[EntryDate] from [dbo].[AspCMSNotice] where [NoticeCategory]='3' and [NoticeStatus]=1 order by [ID]").ToList();
            foreach (dynamic item in Information)
            {
                string ImgPath;
                if (item.AttachFile is DBNull || item.AttachFile == "")
                {
                    ImgPath = "/assets/front-iba/img/newsLetter.jpg";
                }
                else
                {
                    ImgPath = "" + item.AttachFile + "";
                }

                sb.AppendLine("<div class='single-campus-news'>");

                sb.AppendLine("<div class='campus-news-left'>");
                sb.AppendLine("<a href='/NewsLetter/NewsLetterSignleDetails/" + item.ID + "'>");
                sb.AppendLine("<img src=");
                sb.AppendLine(ImgPath);
                sb.AppendLine("/>");
                sb.AppendLine("</a>");
                sb.AppendLine("</div>");

                sb.AppendLine("<div class='campus-news-right'>");
                sb.AppendLine("<h4>");
                sb.AppendLine("<a href='/NewsLetter/NewsLetterSignleDetails/" + item.ID + "'>" + item.NoticeName + "");
                sb.AppendLine("</a>");
                sb.AppendLine("</h4>");

                sb.AppendLine("<h5>" + string.Format("{0:MMM.dd.yyyy}", item.EntryDate) + "");
                sb.AppendLine("</h5>");
                sb.AppendLine("<a href='/NewsLetter/NewsLetterSignleDetails/" + item.ID + "'>read more");
                sb.AppendLine("</a>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");


            }



            return new MvcHtmlString(sb.ToString());
        }
    }
}