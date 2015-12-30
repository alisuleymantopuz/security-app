using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace AuthorizationFramework.Infrastructure.NH
{
    public class NHibernateSessionFactory<T>
    {
        public static ISessionFactory CreateSessionFactory(bool withDbCreation)
        {
            if (withDbCreation)
            {
                return Fluently.Configure()
                .Database(CreateDbConfig)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>().Conventions.AddFromAssemblyOf<EnumConvention>())
                .ExposeConfiguration(DropCreateSchema)
                .BuildSessionFactory();
            }
            else return Fluently.Configure()
               .Database(CreateDbConfig)
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>().Conventions.AddFromAssemblyOf<EnumConvention>())
               .BuildSessionFactory();
        }

        private static MsSqlConfiguration CreateDbConfig()
        {
            return MsSqlConfiguration
                .MsSql2008.IsolationLevel("ReadUncommitted")
                .ConnectionString(InfrastructureConfiguration.ConnectionString).ShowSql();
        }

        private static void DropCreateSchema(Configuration cfg)
        {
            new SchemaExport(cfg)
             .Drop(false, true);

            new SchemaExport(cfg)
                .Create(false, true);
        }
    }


}
