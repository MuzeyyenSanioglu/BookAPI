using BookAPI.DAL.Entities;
using BookAPI.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Infrastructure.Data
{
    public class BookContextSeed
    {
        public static async Task SeedAsync(BookContext bookContext)
        {
          
            if (!bookContext.Books.Any())
            {
                bookContext.Books.AddRange(GetPreconfiguredOrders());

                await bookContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Book> GetPreconfiguredOrders()
        {
            return new List<Book>() {
                new Book() {Author = "J. R. R. Tolkien",
                AuthorDescription  = "John Ronald Reuel Tolkien CBE FRSL (/ˈruːl ˈtɒlkiːn/, ROOL TOL-keen;[a] 3 January 1892 – 2 September 1973) was an English writer, poet, philologist, and academic, best known as the author of the high fantasy works The Hobbit and The Lord of the Rings.",
                BookCoverImageURL = "https://kbimages1-a.akamaihd.net/Images/4929af70-799a-4e4f-a274-9ed39580a532/255/400/False/image.jpg",
                Categories = "High fantasy Adventure",
                ContentDescription = "All three parts of the epic masterpiece The Lord of the Rings – The Fellowship of the Ring, The Two Towers & The Return of the King – available as one download, featuring the definitive edition of the text, hyperlinked footnotes and page references, and 3 maps including a detailed map of Middle-earth.",
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                PageCount = 600,
                IsDeleted = false,
                Title = "The Lord of the Rings: The Fellowship of the Ring, The Two Towers, The Return of the King",
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now,
                UUID = Guid.NewGuid().ToString()
                }
            };
        }
    }
}
