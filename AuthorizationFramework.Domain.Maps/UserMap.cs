using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using FluentNHibernate.Mapping;

namespace AuthorizationFramework.Domain.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("[ApplicationMembership]");
            Table("[User]"); 
            Id(x => x.UserId, "UserId").GeneratedBy.Native(); 
            Map(x => x.UserName, "UserName").CustomSqlType("varchar(50)");
            Map(x => x.UserEmail, "UserEmail").CustomSqlType("varchar(100)");
            Map(x => x.UserPassword, "UserPassword").CustomSqlType("varchar(50)");
            Map(x => x.FullName, "FullName").CustomSqlType("varchar(50)");
            Map(x => x.IsBlocked, "IsBlocked").CustomSqlType("bit").Not.Nullable();
            Map(x => x.LastLoginDate, "LastLoginDate").CustomSqlType("datetime").Nullable();
            Map(x => x.LastPasswordChangeDate, "LastPasswordChangeDate").CustomSqlType("datetime").Nullable();
            Map(x => x.ForceToChangePasswordNextLogon, "ForceToChangePasswordNextLogon").CustomSqlType("bit").Nullable();
            Map(x => x.FailureLoginAttempt, "FailureLoginAttempt").CustomSqlType("int").Nullable();
            Map(x => x.LastLoginIp, "LastLoginIp").CustomSqlType("varchar(15)").Nullable();
            Map(x => x.MobilePhone, "MobilePhone").CustomSqlType("varchar(20)");
            Component(x => x.RecordInformation);
            References<Role>(x => x.Role, "RoleId").Cascade.None().LazyLoad().ForeignKey("FK_User_Role_RoleId");
          
        }
    }
}
