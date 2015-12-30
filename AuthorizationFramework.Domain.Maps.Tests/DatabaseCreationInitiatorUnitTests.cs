using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthorizationFramework.Infrastructure.NH;
using AuthorizationFramework.Domain.AuthorizationAggregate;

namespace AuthorizationFramework.Domain.Maps.Tests
{
    [TestClass]
    public class DatabaseCreationInitiatorUnitTests
    {
        [TestMethod]
        public void CreateDBEnvironment_Test()
        {
            var sessionFactory = NHibernateSessionFactory<RoleMap>.CreateSessionFactory(true);

            var session = sessionFactory.OpenSession();

            var transaction = session.BeginTransaction();

            var role = session.Get<Role>(1);

            transaction.Commit();

            Assert.IsNull(role);
        }
    }
}
