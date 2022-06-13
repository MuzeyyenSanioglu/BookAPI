using BookAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Domain.Data
{
    public class BookContext :DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}