using System.Data.Entity;

namespace Datalayer.Infrastructure
{
    public interface IDbContextProvider
    {
        DbContext GetContext();
    }
}