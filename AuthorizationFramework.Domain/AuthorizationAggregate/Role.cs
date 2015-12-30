using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class Role
    {
        public virtual int RoleId { get; set; }
        public virtual string RoleName { get; set; }
        public virtual IList<RolePagePermission> RolePagePermissions { get; set; }
        public virtual IList<User> Users { get; set; }
        public virtual RoleGroup RoleGroup { get; set; }
        public virtual RecordInformation RecordInformation { get; set; }
        public virtual bool IsTemplate { get; set; }
    }
}
