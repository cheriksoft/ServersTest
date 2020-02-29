using System.Data.Entity;
using Datalayer.Entities;

namespace Datalayer
{
    public class ServersDbContext : DbContext
    {
        public DbSet<VirtualServer> VirtualServers { get; set; }
    }
}