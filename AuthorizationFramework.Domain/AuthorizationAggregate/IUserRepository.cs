using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public interface IUserRepository
    {
        User SearchUserByUserName(string userName);
        User GetUserById(int userId);
        IList<Role> GetAllRoles();
        IList<Page> GetAllPages();
        IList<RolePagePermission> GetAllRolePagePermissions();
        IList<User> GetAllUsers();
        IList<PageType> GetAllPageTypeList();
        RoleGroup GetRoleGroupById(int roleGroupId); 
        IList<RoleGroup> GetAllRoleGroups();
        Role GetRoleByRoleId(int roleId); void CreateUser(User user);
        void EditUser(User user);
        void DeleteUser(User user);
        void CreateRolePagePermission(RolePagePermission rolePagePermission);
        void EditRolePagePermission(RolePagePermission rolePagePermission);
        void DeleteRolePagePermission(RolePagePermission rolePagePermission); void CreateRole(Role role);
        void EditRole(Role role);
        void DeleteRole(Role role);
        void SaveOrUpdateRole(Role role);
        void SaveOrUpdateUser(User user);

    }
}
