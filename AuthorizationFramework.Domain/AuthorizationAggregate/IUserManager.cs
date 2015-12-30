using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public interface IUserManager
    {
        LoginUserResult LoginUser(string username, string password);

        IList<PageType> GetPageTypeList();

        IList<RoleGroup> GetAllRoleGroups();

        IList<Role> GetAllRoles();

        IList<Page> GetAllPages();

        IList<RolePagePermission> GetAllRolePagePermissions();

        IList<RolePagePermission> GetAllRolePagePermissionsByRoleId(int roleId);

        User GetUserByUserName(string username);
    }
}
