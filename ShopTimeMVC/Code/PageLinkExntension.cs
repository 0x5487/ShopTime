using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.Ajax.Utilities;

namespace JasonSoft.ShopTimeMVC
{
    public static class PageLinkExntension
    {

        public static MvcHtmlString PageLink(this HtmlHelper htmlHelper, string linkText, string templateName)
        {
            return htmlHelper.PageLink(linkText, templateName, null, null);
        }

        public static MvcHtmlString PageLink(this HtmlHelper htmlHelper, string linkText, string templateName, object queryString)
        {
            return htmlHelper.PageLink(linkText, templateName, queryString, null);
        }

        public static MvcHtmlString PageLink(this HtmlHelper htmlHelper, string linkText, string templateName, object queryString, object htmlAttributes)
        {
            MvcHtmlString mvcHtmlString = null;

            switch (templateName.ToLower())
            {
                case "home":
                    mvcHtmlString = htmlHelper.ActionLink(linkText, "Index", "Home", queryString, htmlAttributes);
                    break;
                case "productdetail":
                    mvcHtmlString = htmlHelper.ActionLink(linkText, "DisplayProductDetail", "Product", queryString, htmlAttributes);
                    break;
                case "onepagecheckout":
                    mvcHtmlString = htmlHelper.ActionLink(linkText, "Index", "checkout", queryString, htmlAttributes);
                    break;
                case "login":
                    mvcHtmlString = htmlHelper.ActionLink(linkText, "Login", "Account", queryString, htmlAttributes);
                    break;
                case "cart":
                    mvcHtmlString = htmlHelper.ActionLink(linkText, "Index", "cart", queryString, htmlAttributes);
                    break;
                case "forgotpassword":
                    mvcHtmlString = htmlHelper.ActionLink(linkText, "ForgotPassword", "Account", queryString, htmlAttributes);
                    break;

            }

            return mvcHtmlString;
        }
    }
}