using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorizationFramework.Domain.AuthorizationAggregate;

namespace AuthorizationFramework.UI.Web.ServiceHelpers.Security
{
    public class WebPrincipalSerializeModel
    {
        public string Token { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public List<Page> AccessiblePages { get; set; }

        public int UserRoleId { get; set; }

        public int RoleGroupId { get; set; }

        public string RoleGroupName { get; set; }

        public int UserId { get; set; }

        public string UserEmail { get; set; }

        public int RoleLevel { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string LastLoginIp { get; set; }

        public DateTime? LastBatchCloseDate { get; set; }

        public string UserMerchantName { get; set; }
    }
}