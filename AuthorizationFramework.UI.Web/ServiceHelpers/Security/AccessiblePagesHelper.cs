using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using AuthorizationFramework.Domain.Services;

namespace AuthorizationFramework.UI.Web.ServiceHelpers.Security
{
    public class AccessiblePagesHelper
    {
        public UserManager UserManager { get; private set; }

        public AccessiblePagesHelper()
        {
            this.UserManager = new UserManager();
        }

        public IList<RolePagePermission> RolePagePermissionsByRoleId(int roleId)
        {
            return this.UserManager.GetAllRolePagePermissionsByRoleId(roleId);
        } 
    }
}