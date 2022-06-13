using BookAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.Repository.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T enitity);
        void Update(T enitity);
        void Delete(T enitity);
        List<T> GetAll();
    }
}
