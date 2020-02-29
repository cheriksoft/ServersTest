using System;
using System.Collections.Generic;
using Datalayer.Entities;

namespace ServersApp.Models
{
    public interface ITotalUsageTimeCalculatorService
    {
        TimeSpan CalculateForServers(IEnumerable<VirtualServer> servers);
    }
}