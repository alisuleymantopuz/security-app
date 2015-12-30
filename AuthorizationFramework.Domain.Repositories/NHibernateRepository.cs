using AuthorizationFramework.Domain.Maps;
using AuthorizationFramework.Infrastructure.NH;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.Repositories
{
    public class NHibernateRepository
    {
        public ISession Session { get; private set; }

        public NHibernateRepository()
        {
            var sessionFactory = NHibernateSessionFactory<RoleMap>.CreateSessionFactory(false);

            this.Session = sessionFactory.OpenSession();
        }
    }
}
