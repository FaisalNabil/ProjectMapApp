using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace MangroveSpace
{
    public static class AlbumHelper
    {
        public static MvcHtmlString GetAlbumShortList(this HtmlHelper helper)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            MangroveSpaceEntities db = new MangroveSpaceEntities();

            List<dynamic> Information = Global.Sql(db, "select top 6 [ID],[AID],[AlbumTitle],[AlbumOrder],[AlbumImage] from [dbo].[AspCMSAlbum] where [Status]=1 order by [AlbumOrder]").ToList();
            int i = 0;
            foreach (dynamic item in Information)
            {



                i++;
                sb.AppendLine("<div class='col-md-4' data-src='" + item.AlbumImage + "'>");
                sb.AppendLine("<div class='single-gallery'>");
                sb.AppendLine("<div class='img-holder'>");
                if (String.IsNullOrWhiteSpace(item.AlbumImage.ToString()))
                {
                    sb.AppendLine("<img src='/assets/front_assets/IBA/img/gallery-16.jpg'alt='gallery' />");
                }
                else
                {
                    sb.AppendLine("<img src='" + item.AlbumImage + "'alt='gallery' />");
                }
                sb.AppendLine("<div class='overlay-content'>");
                sb.AppendLine("<div class='inner-content'>");
                sb.AppendLine("<div class='title-box'>");
                if (item.AlbumTitle != null)
                {
                    sb.AppendLine("<h3><a  href='/albums/AlbumDetails/" + item.AID + "'>" + item.AlbumTitle + "</a></h3>");
                }
                else
                {
                    sb.AppendLine("<h3><a  href='/albums/AlbumDetails/" + item.AID + "'>" + item.AlbumTitle + "</a></h3>");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='link-zoom-button'>");
                sb.AppendLine("<div class='single-button'>");
                if (item.AlbumTitle != null)
                {
                    sb.AppendLine("<a  href='/albums/AlbumDetails/" + item.AID + "'><span class='fa fa-link'></span>Details</a>");
                }
                else
                {
                    sb.AppendLine("<a  href='/albums/AlbumDetails/" + item.AID + "'><span class='fa fa-link'></span>Details</a>");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='single-button'>");
                if (item.AlbumTitle != null)
                {
                    sb.AppendLine("<a  href='" + item.AlbumImage + "' class='zoom lightbox-image'><span class='fa fa-search'></span>Zoom</a>");
                }
                else
                {
                    sb.AppendLine("<a  href='#'><span class='fa fa-search'></span>Zoom</a>");
                }
                
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");



                //i++;
                //sb.AppendLine("<div class='col-md-4'>");
                //sb.AppendLine("<div class='single-gallery'>");
                //sb.AppendLine("<a href='/albums/AlbumDetails/" + item.AID + "'>");
                //if (String.IsNullOrWhiteSpace(item.AlbumImage.ToString()))
                //{
                //    sb.AppendLine("<img src='/assets/front_assets/IBA/img/gallery-16.jpg'alt='gallery' />");
                //}
                //else
                //{
                //    sb.AppendLine("<img src='" + item.AlbumImage + "'alt='gallery' />");
                //}
                //sb.AppendLine("</a>");
                //sb.AppendLine("<div class='gallery-overlay'>");
                //if (item.AlbumTitle != null)
                //{
                //    sb.AppendLine("<h4>" + item.AlbumTitle + "</h4>");
                //}
                //else
                //{
                //    sb.AppendLine("<h4>Demo</h4>");
                //}
                //sb.AppendLine("</div>");
                //sb.AppendLine("</div>");
                //sb.AppendLine("</div>");


            }

            return new MvcHtmlString(sb.ToString());
        }



        public static MvcHtmlString GetAlbumList(this HtmlHelper helper, int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            MangroveSpaceEntities db = new MangroveSpaceEntities();

            List<dynamic> Information = Global.Sql(db, "select [ADID],[AID],[AlbumDetailsTitle],[AlbumDetailsOrder],[AlbumDetailImagePath] from [dbo].[AspCMSAlbumDetails] where [Status]=1 and [AID]='"+ id + "' order by [AlbumDetailsOrder]").ToList();
            int i = 0;
            foreach (dynamic item in Information)
            {



                i++;
                sb.AppendLine("<div class='col-md-4' data-src='" + item.AlbumDetailImagePath + "'>");
                sb.AppendLine("<div class='single-gallery'>");
                sb.AppendLine("<div class='img-holder'>");
                if (String.IsNullOrWhiteSpace(item.AlbumDetailImagePath.ToString()))
                {
                    sb.AppendLine("<img src='/assets/front_assets/IBA/img/gallery-16.jpg'alt='gallery' />");
                }
                else
                {
                    sb.AppendLine("<img src='" + item.AlbumDetailImagePath + "'alt='gallery' />");
                }
                sb.AppendLine("<div class='overlay-content'>");
                sb.AppendLine("<div class='inner-content'>");
                sb.AppendLine("<div class='title-box'>");
                if (item.AlbumDetailsTitle != null)
                {
                    sb.AppendLine("<h3><a  href='/albums/AlbumDetails/" + item.AID + "'>" + item.AlbumDetailsTitle + "</a></h3>");
                }
                else
                {
                    sb.AppendLine("<h3><a  href='/albums/AlbumDetails/" + item.AID + "'>" + item.AlbumDetailsTitle + "</a></h3>");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='link-zoom-button'>");
                sb.AppendLine("<div class='single-button'>");
                if (item.AlbumDetailsTitle != null)
                {
                    sb.AppendLine("<a  href='#'><span class='fa fa-link'></span>Details</a>");
                }
                else
                {
                    sb.AppendLine("<a  href='#'><span class='fa fa-link'></span>Details</a>");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("<div class='single-button'>");
                if (item.AlbumDetailsTitle != null)
                {
                    sb.AppendLine("<a  href='" + item.AlbumDetailImagePath + "' class='zoom lightbox-image'><span class='fa fa-search'></span>Zoom</a>");
                }
                else
                {
                    sb.AppendLine("<a  href='#'><span class='fa fa-search'></span>Zoom</a>");
                }

                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");


                //i++;
                //sb.AppendLine("<div class='col-md-4'>");
                //sb.AppendLine("<div class='single-gallery-img img-contain-isotope'>");

                //if (String.IsNullOrWhiteSpace(item.AlbumDetailImagePath.ToString()))
                //{
                //    sb.AppendLine("<img src='/assets/front_assets/IBA/img/gallery-14.jpg'alt='gallery' />");
                //}
                //else
                //{
                //    sb.AppendLine("<img src='" + item.AlbumDetailImagePath + "'alt='gallery' />");
                //}
                //sb.AppendLine("<div class='gallery-caption'>");
                //if (item.AlbumTitle != null)
                //{
                //    sb.AppendLine("<p><a  href='" + item.AlbumImage + "' class='more gallery2'><i class='fa fa-fw fa-search-plus'> </i></a></p>");
                //}
                //else
                //{
                //    sb.AppendLine("<h4>" + item.AlbumDetailsTitle + "</h4>");
                //}
                //sb.AppendLine("</div>");
                //sb.AppendLine("</div>");
                //sb.AppendLine("</div>");


            }

            return new MvcHtmlString(sb.ToString());
        }
    }
}