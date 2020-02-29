using System;
using Datalayer.Entities;

namespace Datalayer.Factories
{
    public class VirtualServerFactory : IVirtualServerFactory
    {
        public VirtualServer Create()
        {
            return new VirtualServer() {CreateDateTime = DateTime.Now};
        }
    }
}