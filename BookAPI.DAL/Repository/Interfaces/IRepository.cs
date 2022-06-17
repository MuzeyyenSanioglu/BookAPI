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
        T Add(T enitity);
        T Update(T enitity);
        T Delete(T enitity);
        T DeleteSoft(T entity);
        List<T> GetAll();
    }
}
