using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MangroveSpace
{
    public static class SliderHelper
    {

        public static MvcHtmlString GetSliderImageItem(this HtmlHelper helper)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            string ImgPath;
            int i = 0;
            MangroveSpaceEntities db = new MangroveSpaceEntities();
            List<dynamic> Information = Global.Sql(db,"select * from [dbo].[AspCMSSlider] where [SliderStatus]=1 order by [SliderOrder] ASC").ToList();
            foreach (dynamic item in Information)
            {
                i = i + 1;

                if (item.SliderImagePath is DBNull)
                { ImgPath = "/assets/front-iba/img/tour_backgd.jpg"; }
                else
                { ImgPath = "" + item.SliderImagePath + ""; }


                sb.AppendLine(".slide-item-" + i + "{background: rgba(0, 0, 0, 0.3) url(" + ImgPath + ") no-repeat scroll 0 0 / cover; }");

            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}