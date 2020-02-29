using System;
using System.Linq;
using Datalayer.Entities;
using Datalayer.Repositories;
using ServersApp.Infrastructure;

namespace ServersApp.Models
{
    public class VirtualServersModelBuilder : IVirtualServersModelBuilder
    {
        private readonly IEntityRepository entityRepository;
        private readonly ITotalUsageTimeCalculatorService totalUsageTimeCalculatorService;

        public VirtualServersModelBuilder(IEntityRepository entityRepository,
            ITotalUsageTimeCalculatorService totalUsageTimeCalculatorService)
        {
            this.entityRepository = entityRepository;
            this.totalUsageTimeCalculatorService = totalUsageTimeCalculatorService;
        }

        public VirtualServersListModel Build()
        {
            var items = entityRepository.GetTable<VirtualServer>().ToArray();

            return new VirtualServersListModel(
                DateTime.Now.FormatDate(),
                totalUsageTimeCalculatorService.CalculateForServers(items).FormatTimeSpan(),
                items.Select(x => new VirtualServerItemModel(x.Id, x.CreateDateTime.FormatDate(), x.RemovedDateTime.FormatDate(), x.RemovedDateTime.HasValue)).ToList()
            );
        }
    }
}