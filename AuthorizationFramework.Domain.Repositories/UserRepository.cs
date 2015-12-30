using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace AuthorizationFramework.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        public NHibernateRepository NHibernateRepository { get; private set; }

        public UserRepository()
        {
            this.NHibernateRepository = new NHibernateRepository();
        }

        public User SearchUserByUserName(string userName)
        {
            var query = this.NHibernateRepository.Session.Query<User>();

            return query.FirstOrDefault(x => x.UserName == userName);
        }

        public User GetUserById(int userId)
        {
            return this.NHibernateRepository.Session.Get<User>(userId);
        }

        public IList<Role> GetAllRoles()
        {
            return this.NHibernateRepository.Session.Query<Role>().ToList();
        }

        public IList<Page> GetAllPages()
        {
            return this.NHibernateRepository.Session.Query<Page>().ToList();
        }

        public IList<RolePagePermission> GetAllRolePagePermissions()
        {
            return this.NHibernateRepository.Session.Query<RolePagePermission>().ToList();
        }

        public IList<User> GetAllUsers()
        {
            return this.NHibernateRepository.Session.Query<User>().ToList();
        }

        public IList<PageType> GetAllPageTypeList()
        {
            return this.NHibernateRepository.Session.Query<PageType>().ToList();
        }

        public RoleGroup GetRoleGroupById(int roleGroupId)
        {
            return this.NHibernateRepository.Session.Get<RoleGroup>(roleGroupId);
        }

        public IList<RoleGroup> GetAllRoleGroups()
        {
            return this.NHibernateRepository.Session.Query<RoleGroup>().ToList();
        }

        public Role GetRoleByRoleId(int roleId)
        {
            return this.NHibernateRepository.Session.Get<Role>(roleId);
        }

        public void CreateUser(User user)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.Save(user);

            transaction.Commit();
        }

        public void EditUser(User user)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.SaveOrUpdate(user);

            transaction.Commit();
        }

        public void DeleteUser(User user)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.Delete(user);

            transaction.Commit();
        }

        public void CreateRolePagePermission(RolePagePermission rolePagePermission)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.Save(rolePagePermission);

            transaction.Commit();
        }

        public void EditRolePagePermission(RolePagePermission rolePagePermission)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.SaveOrUpdate(rolePagePermission);

            transaction.Commit();
        }

        public void DeleteRolePagePermission(RolePagePermission rolePagePermission)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.Delete(rolePagePermission);

            transaction.Commit();
        }

        public void CreateRole(Role role)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.Save(role);

            transaction.Commit();
        }

        public void EditRole(Role role)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.SaveOrUpdate(role);

            transaction.Commit();
        }

        public void DeleteRole(Role role)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.Delete(role);

            transaction.Commit();
        }

        public void SaveOrUpdateRole(Role role)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.SaveOrUpdate(role);

            transaction.Commit();
        }

        public void SaveOrUpdateUser(User user)
        {
            var transaction = this.NHibernateRepository.Session.BeginTransaction();

            this.NHibernateRepository.Session.SaveOrUpdate(user);

            transaction.Commit();
        }
    }
}
