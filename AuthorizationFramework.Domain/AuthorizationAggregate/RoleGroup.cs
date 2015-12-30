using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class RoleGroup
    {
        public virtual int RoleGroupId { get; set; }
        public virtual string RoleGroupName { get; set; }
        public virtual int RoleLevel { get; set; }
        public virtual IList<Role> Roles { get; set; }
    }
}
