using BookAPI.DAL.Entities;
using BookAPI.DAL.Repository.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.Repository
{
    public interface IBookrepository : IRepository<Book>
    {
        public List<JObject> GetBooksGroupAndCountByCategory();
        public List<Book> GetaAllBookByKeyword(List<string> keywords);
        public Book GetByUUId(string uuid);
      
    }
}
