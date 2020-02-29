using System;
using System.Data.Entity;
using System.Web;

namespace Datalayer.Infrastructure
{
    /// <summary>
    /// Если мы пишем код с упором на SOLID, в частности на SRP, то чтобы, гуляя по разным классам в рамках одного HTTP-запроса, 
    /// не иметь проблем с передачей одного и того же инстанса контекста EF - сделаем вот такой хелпер
    /// </summary>
    public class PerWebRequestDbContextProvider : IDbContextProvider
    {
        internal const string HTTP_CONTEXT_KEY = "EFContextKey";

        public DbContext GetContext()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                throw new InvalidOperationException("Этот механизм требует привязки к HttpContext");
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