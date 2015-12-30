using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class RecordInformation
    {
        public virtual int CreatorUserId { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? CreateDate { get; set; }
    }
}
