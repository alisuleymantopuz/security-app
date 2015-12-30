using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using AuthorizationFramework.Domain.Services;
using AuthorizationFramework.UI.Web.Models.Account;
using AuthorizationFramework.UI.Web.ServiceHelpers.Security;

namespace AuthorizationFramework.UI.Web.Controllers
{
    using AuthorizationFramework.UI.Web.ServiceHelpers.Security;

    [AllowAnonymous]
    public class AccountController : BaseController
    {
        public UserManager UserManager { get; private set; }
        public FormsAuthenticationService FormsAuthenticationService { get; private set; }
        public AccessiblePagesCachingHelper AccessiblePagesCachingHelper { get; private set; }
        public AccountController()
        {
            this.UserManager = new UserManager();
            this.FormsAuthenticationService = new FormsAuthenticationService();
            this.AccessiblePagesCachingHelper = new AccessiblePagesCachingHelper();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (base.IsAuthorize)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;

            if (TempData != null)
            {
                ViewBag.InfoMessage = TempData["InfoMessage"];
            }

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginResult = this.UserManager.LoginUser(loginViewModel.Username, loginViewModel.Password);

                    if (loginResult.IsSuccess)
                    {
                        User user = loginResult.User;

                        string userData = RetrieveSerializedUserData(user);

                        bool isAccesiblePagesHandled = SetAccessiblePagesForUserRole(user.Role.RoleId);

                        if (!isAccesiblePagesHandled)
                        {
                            ModelState.AddModelError("", "Accessible pages were not handled");
                            return View(loginViewModel);
                        }

                        FormsAuthenticationService.SignIn(loginViewModel.Username, userData, false);

                        if (string.IsNullOrEmpty(returnUrl) == false)
                        {
                            return RedirectPermanent(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login failed..");
                        return View(loginViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username and password can not be null.");
                    return View(loginViewModel);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);
            }

            return View(loginViewModel);
        }

        public string RetrieveSerializedUserData(User user)
        {
            WebPrincipalSerializeModel serializeModel = new WebPrincipalSerializeModel
            {
                UserId = user.UserId,
                FullName = user.FullName,
                UserName = user.UserName,
                UserRoleId = user.Role.RoleId,
                UserEmail = user.UserEmail,
                RoleGroupId = user.Role.RoleGroup.RoleGroupId,
                RoleGroupName = user.Role.RoleName,
                RoleLevel = user.Role.RoleGroup.RoleLevel,
                LastLoginDate = user.LastLoginDate,
                LastLoginIp = user.LastLoginIp,
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(serializeModel);
        }

        private bool SetAccessiblePagesForUserRole(int role)
        {
            try
            {
                var accessiblePages = this.UserManager.GetAllRolePagePermissionsByRoleId(role);

                this.AccessiblePagesCachingHelper.Put(role, accessiblePages.ToList());

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}