using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationFramework.UI.Web.ServiceHelpers.Security
{
    using System.Security.Principal;

    using AuthorizationFramework.Domain.AuthorizationAggregate;
    using AuthorizationFramework.UI.Web.Models.Account;

    public class WebPrincipalHelper
    {
        public UserHelper UserHelper { get; private set; }
        public WebPrincipalHelper()
        {
            this.UserHelper = new UserHelper();
        }

        public WebPrincipal PopulateWebPrincipal(IPrincipal principal)
        {
            if (principal != null && principal.Identity != null)
            {
                User user = this.UserHelper.Get(principal.Identity.Name);
                if (user != null)
                {
                    WebPrincipal webPrincipal = new WebPrincipal(user.UserName)
                    {
                        Email = user.UserEmail,
                        FullName = user.FullName,
                        UserId = user.UserId,
                        Identity = new GenericIdentity(user.UserName),
                        UserName = user.UserName,
                        RoleId = user.Role.RoleId
                    };

                    return webPrincipal;
                }
            }
            return null;
        }
    }
}