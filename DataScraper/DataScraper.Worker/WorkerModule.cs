using Autofac;
using DataScraper.Worker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Worker
{
    public class WorkerModule : Module
    {  
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public WorkerModule(string connectionString, string migrationAssembly)
        {        
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StockDataScraperModel>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
