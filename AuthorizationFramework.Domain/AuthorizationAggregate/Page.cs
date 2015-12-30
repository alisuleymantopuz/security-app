using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class Page
    {
        public virtual int PageId { get; set; }
        public virtual string MenuTitle { get; set; }
        public virtual string MenuTitleInEnglish { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual bool IsMenuPage { get; set; }
        public virtual PageType PageType { get; set; }
        public virtual int RowOrder { get; set; }
        public virtual Page ParentPage { get; set; }
    }
}
