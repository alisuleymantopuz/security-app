using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using FluentNHibernate.Mapping;

namespace AuthorizationFramework.Domain.Maps
{
    public class RolePagePermissionMap : ClassMap<RolePagePermission>
    {
        public RolePagePermissionMap()
        {
            Schema("[ApplicationMembership]");
            Table("[RolePagePermission]");

            Id(x => x.RolePagePermissionId, "RolePagePermissionId").GeneratedBy.Native();
            Map(x => x.IsActive, "IsActive").CustomSqlType("bit").Not.Nullable();
            References<Role>(x => x.Role, "RoleId").Cascade.None().ForeignKey("Fk_RolePagePermission_Role_RoleId");
            References<Page>(x => x.Page, "PageId").Cascade.None().ForeignKey("Fk_RolePagePermission_Page_PageId");
        }
    }
}
