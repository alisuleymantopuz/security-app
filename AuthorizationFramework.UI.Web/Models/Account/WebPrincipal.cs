using AuthorizationFramework.Domain.AuthorizationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web; 

namespace AuthorizationFramework.UI.Web.Models.Account
{
    public class WebPrincipal : IWebPrincipal
    {
        public WebPrincipal(string userName)
        {
            this.Identity = new GenericIdentity(userName);
        }
         
        public int UserId { get; set; }
         
        public string UserName { get; set; }

        public string FullName { get; set; } 

        public int RoleId { get; set; }

        public string Email { get; set; }

        public IIdentity Identity { get; set; }
         
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
         
    }
}