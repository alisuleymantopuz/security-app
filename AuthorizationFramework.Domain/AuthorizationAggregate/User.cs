using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserPassword { get; set; }
        public virtual string UserEmail { get; set; }
        public virtual string FullName { get; set; }
        public virtual string MobilePhone { get; set; }
        public virtual bool IsBlocked { get; set; }
        public virtual int? FailureLoginAttempt { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual DateTime LastPasswordChangeDate { get; set; }
        public virtual bool ForceToChangePasswordNextLogon { get; set; }
        public virtual string LastLoginIp { get; set; }
        public virtual Role Role { get; set; }
        public virtual RecordInformation RecordInformation { get; set; }
        public virtual int? UserEditor { get; set; }
        public virtual bool PasswordChanged { get; set; }
    }
}
