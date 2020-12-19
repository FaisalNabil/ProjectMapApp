using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace
{
    public static class NoticeHelper
    {
        public static MvcHtmlString GetShortNoticeItem(this HtmlHelper helper)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            MangroveSpaceEntities db = new MangroveSpaceEntities();

            List<dynamic> Information = Global.Sql(db, "").ToList();
            foreach (dynamic item in Information)
            {
                string ImgPath = "/assets/front_assets/IBA/img/notice.jpg";
                sb.AppendLine("<li>");
                sb.AppendLine("<div class='notice-left'>");
                sb.AppendLine("<a href='/Notice/NoticeSignleDetails/" + item.ID + "'>");
                sb.AppendLine("<img src=");
                sb.AppendLine(ImgPath);
                sb.AppendLine("/>");
                sb.AppendLine("</a>");
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='notice-right'>");
                sb.AppendLine("<h3>");
                sb.AppendLine("<a href='/Notice/NoticeDetails/" + item.ID + "'>" + item.NoticeName + "");
                sb.AppendLine("</a>");
                sb.AppendLine("</h3>");
                sb.AppendLine("<a href='/Notice/NoticeDetails/" + item.ID + "'>read more");
                sb.AppendLine("</a>");
                sb.AppendLine("</div>");
                sb.AppendLine("</li>");

            }

            return new MvcHtmlString(sb.ToString());
        }

    }
}