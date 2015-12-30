namespace AuthorizationFramework.UI.Web.ServiceHelpers.Security
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    using AuthorizationFramework.Domain.AuthorizationAggregate;

    using AuthorizationFramework.UI.Web.Models.Account;
    using AuthorizationFramework.UI.Web.ServiceHelpers.Security;

    public class AccessiblePagesCachingHelper
    {
        public AccessiblePagesHelper AccessiblePagesHelper { get; private set; }

        public AccessiblePagesCachingHelper()
        {
            this.AccessiblePagesHelper = new AccessiblePagesHelper();
        }

        internal object Get(WebPrincipal webPrincipal)
        {
            if (webPrincipal == null)
                return null;

            string cacheKey = string.Format("{0}_Accessible_Pages", webPrincipal.RoleId);
            if (HttpContext.Current.Cache[cacheKey] == null)
            {
                var time = DateTime.Now.AddMinutes(11);
                var expiration = System.Web.Caching.Cache.NoSlidingExpiration;
                var priority = System.Web.Caching.CacheItemPriority.Normal;

                HttpContext.Current.Cache.Add(cacheKey, this.AccessiblePagesHelper.RolePagePermissionsByRoleId(webPrincipal.RoleId), null, time, expiration, priority, null);
            }

            return HttpContext.Current.Cache[cacheKey];
        }

        internal object Put(int roleId, IList<RolePagePermission> accessiblePages)
        {
            string cacheKey = string.Format("{0}_Accessible_Pages", roleId);

            var time = DateTime.Now.AddMinutes(11);
            var expiration = System.Web.Caching.Cache.NoSlidingExpiration;
            var priority = System.Web.Caching.CacheItemPriority.Normal;

            HttpContext.Current.Cache.Add(cacheKey, accessiblePages, null, time, expiration, priority, null);

            return HttpContext.Current.Cache[cacheKey];
        }
    }
}