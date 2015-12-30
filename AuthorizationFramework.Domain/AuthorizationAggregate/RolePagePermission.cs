using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class RolePagePermission
    {
        public virtual int RolePagePermissionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Page Page { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
