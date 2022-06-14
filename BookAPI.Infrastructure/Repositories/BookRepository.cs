using BookAPI.DAL.Entities;
using BookAPI.DAL.Repository;
using BookAPI.Domain.Data;
using BookAPI.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookrepository
    {
        public BookRepository(BookContext dbContext) : base(dbContext)
        {
        }

        public List<Book> GetaAllBookByKeyword(List<string> keywords)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> GetBooksGroupAndCountByCategory()
        {
            throw new NotImplementedException();
        }

        public Book GetByUUId(string uuid)
        {
           return _dbContext.Set<Book>().FirstOrDefault(s => s.UUID == uuid);
        }
    }
}
