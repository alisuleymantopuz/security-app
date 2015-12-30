using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationFramework.Domain.AuthorizationAggregate;
using FluentNHibernate.Mapping;

namespace AuthorizationFramework.Domain.Maps
{
    public class RecordInformationMap : ComponentMap<RecordInformation>
    {
        public RecordInformationMap()
        {
            Map(x => x.CreateDate, "CreateDate").CustomSqlType("datetime").Nullable();
            Map(x => x.CreatorUserId, "CreatorUserId").CustomSqlType("int").Nullable();
            Map(x => x.IsActive, "IsActive").CustomSqlType("bit").Nullable();
            Map(x => x.IsDeleted, "IsDeleted").CustomSqlType("bit").Nullable();
        }
    }
}
