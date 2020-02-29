namespace ServersApp.Models
{
    public class VirtualServerItemModel
    {
        public int VirtualServerId { get; set; }
        public string CreateDateTime { get; set; }
        public string RemoveDateTime { get; set; }
        public bool IsRemoved { get; set; }

        public VirtualServerItemModel(int virtualServerId, string createDateTime, string removeDateTime, bool isRemoved)
        {
            VirtualServerId = virtualServerId;
            CreateDateTime = createDateTime;
            RemoveDateTime = removeDateTime;
            IsRemoved = isRemoved;
        }
    }
}