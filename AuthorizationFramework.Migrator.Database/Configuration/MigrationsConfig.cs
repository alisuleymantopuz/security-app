using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Migrator.Database.Configuration
{
    using System.Configuration;

    public class MigrationsConfig
    {
        public static void Start()
        {
            Console.WriteLine("Migration is starting...");

            var connectionString = ConfigurationManager.AppSettings["DefaultConnection"];

            var migrator = new Migrator(connectionString, "sqlserver");

            Console.WriteLine("Migration is started...");

            try
            {
                migrator.Migrate(runner => runner.MigrateUp());
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.White;

                GenerateExceptionMessage(exception);

                Console.ForegroundColor = ConsoleColor.Green;

                migrator.Migrate(runner => runner.MigrateDown(0));
            }
        }

        private static void GenerateExceptionMessage(Exception exception)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(">> {0}", exception.Message);
            Console.WriteLine(string.Empty);
        }
    }
}
