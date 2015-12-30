using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using FluentNHibernate.Mapping;

namespace AuthorizationFramework.Domain.Maps
{
    public class RoleGroupMap : ClassMap<RoleGroup>
    {
        public RoleGroupMap()
        {
            Schema("[ApplicationMembership]");
            Table("[RoleGroup]");
            Id(x => x.RoleGroupId, "RoleGroupId").GeneratedBy.Native();
            Map(x => x.RoleGroupName, "RoleGroupName").CustomSqlType("varchar(100)").Not.Nullable();
            Map(x => x.RoleLevel, "RoleLevel").CustomSqlType("smallint").Not.Nullable();
            HasMany<Role>(x => x.Roles).KeyColumn("RoleGroupId").Inverse().AsBag().Cascade.None().LazyLoad();
        }
    }
}
