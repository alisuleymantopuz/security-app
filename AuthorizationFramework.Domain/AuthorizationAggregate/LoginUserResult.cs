using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public class LoginUserResult
    {
        public User User { get; set; }

        public bool IsSuccess { get; set; }
    }
}
