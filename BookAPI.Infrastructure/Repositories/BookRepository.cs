using BookAPI.DAL.Entities;
using BookAPI.DAL.Repository;
using BookAPI.Domain.Data;
using BookAPI.Infrastructure.Repositories.Base;
using Newtonsoft.Json.Linq;
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

        public List<JObject> GetBooksGroupAndCountByCategory()
        {
            var groupByCategory = _dbContext.Set<Book>()
                .GroupBy(s => s.Categories)
                .Select(category => new { Category = category.Key, BookCount = category.Count()});
            List <JObject> result = new List<JObject>();
            foreach (var item in groupByCategory)
            {
                dynamic categoryObject = new JObject();
                categoryObject.Category = item.Category;
                categoryObject.BookCount = item.BookCount;
                result.Add(categoryObject);
            }
            
            return result;
        }

        public Book GetByUUId(string uuid)
        {
           return _dbContext.Set<Book>().FirstOrDefault(s => s.UUID == uuid);
        }
    }
}
