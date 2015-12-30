using System.Reflection;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.Routing;
using System.Security.Cryptography;
using System.Text;
using AuthorizationFramework.UI.Web.Filters;
using AuthorizationFramework.UI.Web.Models.Account;
using AuthorizationFramework.UI.Web.ServiceHelpers.Security;

namespace AuthorizationFramework.UI.Web.Controllers
{
    using AuthorizationFramework.UI.Web;
    using AuthorizationFramework.UI.Web.ServiceHelpers.Security;

    [IsJsonRequest]
    [RoleBasedAuthorize]
    [ValidateAntiForgeryTokenWrapper(HttpVerbs.Post)]
    public class BaseController : Controller
    {
        public bool IsJsonRequest { get; set; }
        public List<Page> AccessiblePages { get; private set; }
        public WebSiteConfiguration WebSiteConfiguration { get; private set; }
        public WebPrincipal WebPrincipal { get; private set; }
        public string InvokedControllerName { get; private set; }
        public string InvokedActionName { get; private set; }
        public AccessiblePagesCachingHelper AccessiblePagesCachingHelper { get; private set; }


        public BaseController()
        {
            AccessiblePagesCachingHelper = new AccessiblePagesCachingHelper();

            this.WebSiteConfiguration = new WebSiteConfiguration();

            this.WebPrincipal = System.Web.HttpContext.Current.User as WebPrincipal;

            if (WebPrincipal != null)
            {
                var cacheData = AccessiblePagesCachingHelper.Get(WebPrincipal);
                if (cacheData != null)
                {
                    this.AccessiblePages = cacheData as List<Page>;
                }
            }


            SetStaticViewBagMessages();
        }

        private void SetStaticViewBagMessages()
        {
            ViewBag.Login = "Login";
        }


        protected override void Initialize(RequestContext rc)
        {
            base.Initialize(rc);
            InvokedControllerName = rc.RouteData.Values["controller"].ToString();
            InvokedActionName = rc.RouteData.Values["action"].ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.AccessiblePages = null;
            }
            base.Dispose(disposing);
        }

        protected virtual new WebPrincipal User
        {
            get { return System.Web.HttpContext.Current.User as WebPrincipal; }
        }

        public int CurrentUserId
        {
            get
            {
                return User.UserId;
            }

        }

        public string CurrentUserIp
        {
            get
            {
                if (this.HttpContext.Request.Headers != null && !string.IsNullOrEmpty(this.HttpContext.Request.Headers["ORIGIP"]))
                {
                    return this.HttpContext.Request.Headers["ORIGIP"];
                }
                else
                {
                    return this.HttpContext.Request.UserHostAddress;
                }
            }
        }

        public bool HasPermission(string controllerName, string actionName)
        {
            if (this.AccessiblePages == null)
            {
                return false;
            }

            return this.AccessiblePages.Any(x => x.Controller == controllerName && x.Action == actionName);
        }

        public bool IsAuthorize
        {
            get
            {
                if (HttpContext.Request.IsAuthenticated && this.AccessiblePages != null)
                {
                    return true;
                }
                return false;
            }
        }

        public string RequestUserHostMerchantNumber { get; set; }

        public int? RoleGroupId { get; set; }

    }
}
