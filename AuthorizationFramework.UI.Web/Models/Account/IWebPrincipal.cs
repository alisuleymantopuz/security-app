using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;

namespace AuthorizationFramework.UI.Web.Models.Account
{
    public interface IWebPrincipal : IPrincipal
    {
         

        string UserName { get; }

        string FullName { get; }
         
        int RoleId { get; }

        string Email { get; }

        int UserId { get; }
    }
}
