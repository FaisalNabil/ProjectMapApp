using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace
{
    public static class EventHelper
    {
        public static MvcHtmlString GetShortEventItem(this HtmlHelper helper)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            MangroveSpaceEntities db = new MangroveSpaceEntities();

            List<dynamic> Information = Global.Sql(db, "select top 4 [ID],[EventID],[EventName],[EventDate],[AttachFile],[Time1],[Time2],[EntryDate] from [dbo].[AspCMSEvent] where [EventStatus]=1 order by [ID]").ToList();
            foreach (dynamic item in Information)
            {
                sb.AppendLine("<div class='single-campus-news'>");
                sb.AppendLine("<div class='campus-events-left'>");
                sb.AppendLine("<h3>" + string.Format("{0:MMM}", item.EventDate) + "");
                sb.AppendLine("<span>" + string.Format("{0:dd}", item.EventDate) + "");
                sb.AppendLine("</span>");
                sb.AppendLine("</h3>");
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='campus-events-right'>");
                sb.AppendLine("<h4>");
                sb.AppendLine("<a href='/Event/EventDetails'>" + item.EventName + "");
                sb.AppendLine("</a>");
                sb.AppendLine("</h4>");
                sb.AppendLine("<h5>" + item.Time1 + " - " + item.Time2 + "</h5>");
                sb.AppendLine("<a href='/Event/EventSignleDetails/" + item.ID + "'>read more about this event</a>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");

            }

            return new MvcHtmlString(sb.ToString());
        }
    }
}