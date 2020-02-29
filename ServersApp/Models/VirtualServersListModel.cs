using System.Collections;
using System.Collections.Generic;

namespace ServersApp.Models
{
    public class VirtualServersListModel
    {
        public string CurrentDateTime { get; set; }
        public string TotalUsageTime { get; set; }
        public IList<VirtualServerItemModel> Servers { get; set; }

        public VirtualServersListModel(string currentDateTime, string totalUsageTime, IList<VirtualServerItemModel> servers)
        {
            CurrentDateTime = currentDateTime;
            TotalUsageTime = totalUsageTime;
            Servers = servers;
        }
    }
}