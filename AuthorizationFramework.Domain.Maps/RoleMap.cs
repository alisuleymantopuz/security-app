using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using FluentNHibernate.Mapping;

namespace AuthorizationFramework.Domain.Maps
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Schema("[ApplicationMembership]");
            Table("[Role]");
            Id(x => x.RoleId, "RoleId").GeneratedBy.Native(); 
            Map(x => x.RoleName, "RoleName").CustomSqlType("varchar(50)");
            Map(x => x.IsTemplate, "IsTemplate").CustomSqlType("bit").Nullable();
            Component(x => x.RecordInformation);
            HasMany<User>(x => x.Users).KeyColumn("RoleId").Inverse().AsBag().Cascade.None().LazyLoad();
            HasMany<RolePagePermission>(x => x.RolePagePermissions).KeyColumn("RoleId").Inverse().AsBag().Cascade.AllDeleteOrphan().LazyLoad();
            References<RoleGroup>(x => x.RoleGroup, "RoleGroupId").Cascade.None().LazyLoad().ForeignKey("FK_Role_RoleGroup_RoleGroupId");
        }
    }
}
