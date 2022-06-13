using BookAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.DataAccess
{
    public class BooksContext :DbContext
    {

        private static string conStr = "Data Source=localhost;Initial Catalog=Books;Integrated Security=False;User ID=sa;Password=Lf12345!";
        public BooksContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(conStr);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
