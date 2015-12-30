using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class PageType
    {
        public virtual int PageTypeId { get; set; }
        public virtual string PageTypeDescription { get; set; }
        public virtual string PageTypeDescriptionCode { get; set; }
        public virtual IList<Page> Pages { get; set; }
    }
}
