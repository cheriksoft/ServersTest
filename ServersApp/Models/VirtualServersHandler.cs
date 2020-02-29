using System;
using System.Collections.Generic;
using System.Linq;
using Datalayer.Entities;
using Datalayer.Factories;
using Datalayer.Repositories;

namespace ServersApp.Models
{
    public class VirtualServersHandler : IVirtualServersHandler
    {
        private readonly IEntityRepository entityRepository;
        private readonly IVirtualServerFactory virtualServerFactory;

        public VirtualServersHandler(IEntityRepository entityRepository, IVirtualServerFactory virtualServerFactory)
        {
            this.entityRepository = entityRepository;
            this.virtualServerFactory = virtualServerFactory;
        }

        public void Create()
        {
            var newServer = virtualServerFactory.Create();
            entityRepository.Insert(newServer);
            entityRepository.SaveChanges();
        }

        public void Delete(IList<int> ids)
        {
            var serversToDelete = entityRepository.GetTable<VirtualServer>().Where(x => ids.Contains(x.Id)).ToArray();

            foreach (var virtualServer in serversToDelete)
            {
                virtualServer.RemovedDateTime = DateTime.Now;
            }

            entityRepository.SaveChanges();

        }
    }
}