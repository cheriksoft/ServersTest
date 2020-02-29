using Datalayer.Entities;

namespace Datalayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Datalayer.ServersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Если у нас пустая БД - заполним тестовым сервером, созданным час назад
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(Datalayer.ServersDbContext context)
        {
            var entriesCount = context.VirtualServers.Count();

            if (entriesCount == 0)
            {
                context.VirtualServers.Add(new VirtualServer() {CreateDateTime = DateTime.Now.AddHours(-1)});
            }
        }
    }
}
