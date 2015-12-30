using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Domain.AuthorizationAggregate
{
    public enum RoleGroupEnum
    {
        SystemAdmin = 1,
        BankUser = 2,
        MerchantAdmin = 3,
        User = 4
    }
}
