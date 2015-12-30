using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using FluentNHibernate.Mapping;

namespace AuthorizationFramework.Domain.Maps
{
    public class PageTypeMap : ClassMap<PageType>
    {
        public PageTypeMap()
        {
            Schema("[ApplicationMembership]");
            Table("[PageType]");
            Id(x => x.PageTypeId, "PageTypeId").GeneratedBy.Native();
            Map(x => x.PageTypeDescription, "PageTypeDescription").CustomSqlType("varchar(100)").Not.Nullable();
            Map(x => x.PageTypeDescriptionCode, "PageTypeDescriptionCode").CustomSqlType("varchar(50)").Not.Nullable();
        }
    }
}
