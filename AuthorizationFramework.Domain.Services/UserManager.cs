using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using AuthorizationFramework.Domain.Repositories;

namespace AuthorizationFramework.Domain.Services
{
    public class UserManager : IUserManager
    {
        public UserRepository UserRepository { get; private set; }

        public PageRepository PageRepository { get; private set; }

        public UserManager()
        {
            this.UserRepository = new UserRepository();

            this.PageRepository = new PageRepository();
        }

        public LoginUserResult LoginUser(string userName, string password)
        {
            var loginUserResult = new LoginUserResult();

            var searchResult = this.UserRepository.GetAllUsers().FirstOrDefault(x => x.UserName == userName && x.UserPassword == password);

            if (searchResult == null)
            {
                loginUserResult.IsSuccess = false;
                return loginUserResult;
            }

            if (searchResult.IsBlocked)
            {
                loginUserResult.IsSuccess = false;
                return loginUserResult;
            }

            loginUserResult.User = searchResult;
            loginUserResult.IsSuccess = true;

            return loginUserResult;
        }

        public IList<PageType> GetPageTypeList()
        {
            return this.PageRepository.GetAllPageTypes();
        }

        public IList<RoleGroup> GetAllRoleGroups()
        {
            return this.UserRepository.GetAllRoleGroups();
        }

        public IList<Role> GetAllRoles()
        {
            return this.UserRepository.GetAllRoles();
        }

        public IList<Page> GetAllPages()
        {
            return this.PageRepository.GetAllPages();
        }

        public IList<RolePagePermission> GetAllRolePagePermissions()
        {
            return this.UserRepository.GetAllRolePagePermissions();
        }


        public IList<RolePagePermission> GetAllRolePagePermissionsByRoleId(int roleId)
        {
            return this.UserRepository.GetAllRolePagePermissions().Where(x => x.Role.RoleId == roleId).ToList();
        }


        public User GetUserByUserName(string username)
        {
            return this.UserRepository.GetAllUsers().FirstOrDefault(x => x.UserName == username);
        }
    }
}
