using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using FluentNHibernate.Mapping;

namespace AuthorizationFramework.Domain.Maps
{
    public class PageMap : ClassMap<Page>
    {
        public PageMap()
        {
            Schema("[ApplicationMembership]");
            Table("[Page]");
            Id(x => x.PageId, "PageId").GeneratedBy.Native();

            Map(x => x.MenuTitle, "MenuTitle").CustomSqlType("varchar(50)");
            Map(x => x.MenuTitleInEnglish, "MenuTitleInEnglish").CustomSqlType("varchar(100)");
            Map(x => x.Action, "Action").CustomSqlType("varchar(20)");
            Map(x => x.Controller, "Controller").CustomSqlType("varchar(20)");
            Map(x => x.IsMenuPage, "IsMenuPage").CustomSqlType("bit");
            Map(x => x.RowOrder, "RowOrder").CustomSqlType("int");
            References<PageType>(x => x.PageType, "PageType").Cascade.None().LazyLoad().ForeignKey("FK_Page_PageType_PageTypeId");
            References<Page>(x => x.ParentPage, "ParentPageId").Cascade.None().LazyLoad().ForeignKey("FK_Page_Page_PageId");
        }
    }
}
