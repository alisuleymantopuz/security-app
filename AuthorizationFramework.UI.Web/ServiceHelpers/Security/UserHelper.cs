using AuthorizationFramework.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationFramework.UI.Web.ServiceHelpers.Security
{
    using AuthorizationFramework.Domain.AuthorizationAggregate;

    public class UserHelper
    {
        public UserManager UserManager { get; private set; }

        public UserHelper()
        {
          this.UserManager =new UserManager();
        }

        public User Get(string username)
        {
            return this.UserManager.GetUserByUserName(username);
        }
    }
}