using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace AuthorizationFramework.Migrator.Database.Migrations
{

    [Migration(101)]
    public class Migration101 : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Schema("ApplicationMembership");
        }
    }
}
