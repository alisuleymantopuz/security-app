using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Migrator.Database
{
    using AuthorizationFramework.Migrator.Database.Configuration;

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            MigrationsConfig.Start();

            Console.WriteLine("Press any key to complete migration..");

            Console.ReadKey();
        }
    }
}
