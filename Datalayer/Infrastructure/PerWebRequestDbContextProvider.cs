using System;
using System.Data.Entity;
using System.Web;

namespace Datalayer.Infrastructure
{
    /// <summary>
    /// ���� �� ����� ��� � ������ �� SOLID, � ��������� �� SRP, �� �����, ����� �� ������ ������� � ������ ������ HTTP-�������, 
    /// �� ����� ������� � ��������� ������ � ���� �� �������� ��������� EF - ������� ��� ����� ������
    /// </summary>
    public class PerWebRequestDbContextProvider : IDbContextProvider
    {
        internal const string HTTP_CONTEXT_KEY = "EFContextKey";

        public DbContext GetContext()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                throw new InvalidOperationException("���� �������� ������� �������� � HttpContext");
            }

            if (!httpContext.Items.Contains(HTTP_CONTEXT_KEY))
            {
                var context = (DbContext)Activator.CreateInstance(typeof(ServersDbContext));
                httpContext.Items[HTTP_CONTEXT_KEY] = context;
            }

            return (DbContext)httpContext.Items[HTTP_CONTEXT_KEY];
        }
    }
}