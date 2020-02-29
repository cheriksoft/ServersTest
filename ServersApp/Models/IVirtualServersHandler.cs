using System.Collections;
using System.Collections.Generic;

namespace ServersApp.Models
{
    public interface IVirtualServersHandler
    {
        void Create();
        void Delete(IList<int> ids);
    }
}