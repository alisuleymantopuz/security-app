using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public interface IPageRepository
    {
        PageType GetPageType(int id);
        IList<PageType> GetAllPageTypes(); 
        IList<Page> GetAllPages();
    }
}
