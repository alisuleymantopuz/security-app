using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AuthorizationFramework.UI.Web.Models.Account;
using AuthorizationFramework.UI.Web.ServiceHelpers.Security;
using AuthorizationFramework.Domain.AuthorizationAggregate;

namespace AuthorizationFramework.UI.Web.Filters
{
    using AuthorizationFramework.UI.Web.ServiceHelpers.Security;

    public class RoleBasedAuthorizeAttribute : AuthorizeAttribute
    {
        public AccessiblePagesCachingHelper AccessiblePagesCachingHelper { get; private set; }

        public WebPrincipalHelper WebPrincipalHelper { get; private set; }

        public RoleBasedAuthorizeAttribute()
        {
            AccessiblePagesCachingHelper = new AccessiblePagesCachingHelper();

            WebPrincipalHelper = new WebPrincipalHelper();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.Request.IsAuthenticated)
                return false;

            string controller = RouteTable.Routes.GetRouteData(httpContext).Values["controller"].ToString();
            string action = RouteTable.Routes.GetRouteData(httpContext).Values["action"].ToString();
            List<Page> accessiblePages = null;

            WebPrincipal webPrincipal = this.WebPrincipalHelper.PopulateWebPrincipal(
                System.Web.HttpContext.Current.User);
            if (webPrincipal != null)
            {
                var cacheData = AccessiblePagesCachingHelper.Get(webPrincipal);
                if (cacheData != null)
                {
                    accessiblePages = cacheData as List<Page>;
                }
            }

            return IsUserAuthorizedToAction(accessiblePages, controller, action);
        }

        private bool IsUserAuthorizedToAction(List<Page> accessiblePages, string controller, string action)
        {
            if (accessiblePages == null)
            {
                return false;
            }
            foreach (var page in accessiblePages)
            {
                if (page.Controller == controller && page.Action == action)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                WebPrincipal webPrincipal =
                    this.WebPrincipalHelper.PopulateWebPrincipal(System.Web.HttpContext.Current.User);
                if (webPrincipal != null)
                {
                    var cacheData = AccessiblePagesCachingHelper.Get(webPrincipal);
                    if (cacheData == null)
                    {
                        base.HandleUnauthorizedRequest(filterContext);
                        return;
                    }
                }
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary 
                                   {
                                       { "action", "GenericError" },
                                       { "controller", "Error" }
                                   });
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}