using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Odev6.ActiveFolder
{
    public static class ActiveClass
    {
        public static string ActivePage(this HtmlHelper html,string control,string action)
        {
            string active = "";
            var routedata =     html.ViewContext.RouteData;
            string routecontrol = (string)routedata.Values["controller"];
            string routeaction = (string)routedata.Values["action"];
            if (routecontrol == control && routeaction == action) active = "active";

            return active;

        }
    }
}