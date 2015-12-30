using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using NHibernate.Linq;

namespace AuthorizationFramework.Domain.Repositories
{
    public class PageRepository : IPageRepository
    {
        public NHibernateRepository NHibernateRepository { get; private set; }

        public PageRepository()
        {
            this.NHibernateRepository = new NHibernateRepository();
        }

        public PageType GetPageType(int id)
        {
            return this.NHibernateRepository.Session.Get<PageType>(id);
        }

        public IList<PageType> GetAllPageTypes()
        {
            return this.NHibernateRepository.Session.Query<PageType>().ToList();
        }

        public IList<Page> GetAllPages()
        {
            return this.NHibernateRepository.Session.Query<Page>().ToList();
        }
    }
}
