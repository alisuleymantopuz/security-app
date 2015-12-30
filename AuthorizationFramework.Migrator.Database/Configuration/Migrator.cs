using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationFramework.Migrator.Database.Configuration
{
    using System.Reflection;

    using FluentMigrator.Runner;
    using FluentMigrator.Runner.Announcers;
    using FluentMigrator.Runner.Initialization;

    public class Migrator
    {
        readonly string _connectionString;
        readonly string _dbType;

        public Migrator(string connectionString, string dbType)
        {
            _connectionString = connectionString;
            _dbType = dbType;
        }

        public void Migrate(Action<IMigrationRunner> runnerAction)
        {
            var options = new MigrationOptions { PreviewOnly = false, Timeout = 0 };

            var factory = new FluentMigrator.Runner.Processors.MigrationProcessorFactoryProvider().GetFactory(_dbType);

            var assembly = Assembly.GetExecutingAssembly();

            var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));

            announcer.Say("test");

            var migrationContext = new RunnerContext(announcer);

            var processor = factory.Create(_connectionString, announcer, options);

            var runner = new MigrationRunner(assembly, migrationContext, processor);

            runnerAction(runner);
        }
    }
}
