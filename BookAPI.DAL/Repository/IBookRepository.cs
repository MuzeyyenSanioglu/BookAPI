using BookAPI.DAL.Entities;
using BookAPI.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.Repository
{
    public interface IBookrepository : IRepository<Book>
    {
        public List<dynamic> GetBooksGroupAndCountByCategory();
    }
}
