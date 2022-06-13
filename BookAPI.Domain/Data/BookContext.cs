using BookAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Domain.Data
{
    public class BookContext :DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        DbSet<Book> Books { get; set; }
    }
}