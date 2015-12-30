using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AuthorizationFramework.UI.Web.ServiceHelpers.Security
{
   public interface IFormsAuthenticationService
    {
        void SignIn(string userName, string userData, bool createPersistentCookie);
        void RefreshAuthentication(HttpCookie authCookie, bool createPersistentCookie);
    }
}
