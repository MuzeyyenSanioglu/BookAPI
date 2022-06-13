using BookAPI.DAL.DataAccess;
using BookAPI.DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksContext _context;

        public UnitOfWork(BooksContext context)
        {
        }
        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
