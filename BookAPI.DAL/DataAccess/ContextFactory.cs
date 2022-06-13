using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.DataAccess
{
    public class ContextFactory : IDisposable
    {
        private bool _disposed;
        private Func<BooksContext> _instanceContext;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ?? (_dbContext = _instanceContext.Invoke());
        public ContextFactory(Func<BooksContext> dbContextFactory)
        {

        }
        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
