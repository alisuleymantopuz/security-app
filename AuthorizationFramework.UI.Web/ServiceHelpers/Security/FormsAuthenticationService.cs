using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AuthorizationFramework.UI.Web.ServiceHelpers.Security
{
    using AuthorizationFramework.UI.Web;

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public WebSiteConfiguration WebSiteConfiguration { get; private set; }

        public FormsAuthenticationService()
        {
            this.WebSiteConfiguration = new WebSiteConfiguration();
        }

        public static string FormsCookieName
        {
            get { return FormsAuthentication.FormsCookieName; }
        }

        public static FormsAuthenticationTicket Decrypt(string authCookieValue)
        {
            return FormsAuthentication.Decrypt(authCookieValue);
        }

        public void SignIn(string userName, string userData, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("required.", "UserName");
            }

            int timeout = 15;

            var expirationTime = DateTime.Now.AddMinutes(timeout);
            if (createPersistentCookie)
            {
                expirationTime = DateTime.Now.AddDays(2);
            }

            var ticket = new FormsAuthenticationTicket(1,
                                                       userName, DateTime.Now,
                                                       expirationTime,
                                                       createPersistentCookie, userData,
                                                       FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var cookie = new HttpCookie("Account", encryptedTicket);

            // Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;

            HttpContext.Current.Response.Cookies.Add(cookie);

            FormsAuthentication.SetAuthCookie(userName, true);
        }

        public void RefreshAuthentication(HttpCookie authCookie, bool createPersistentCookie)
        {
            FormsAuthenticationTicket authTicket = FormsAuthenticationService.Decrypt(authCookie.Value);
            string userName = authTicket.Name;
            string userData = authTicket.UserData;
            SignIn(userName, userData, createPersistentCookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();

            HttpCookie accountCookie = new HttpCookie("Account", "");
            accountCookie.Expires = DateTime.Now.AddYears(-1);
            accountCookie.Path = FormsAuthentication.FormsCookiePath;
            accountCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(accountCookie);

            HttpCookie aspNetSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            aspNetSessionCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(aspNetSessionCookie);
        }
    }
}