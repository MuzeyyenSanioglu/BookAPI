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
                },
                new Book() {Author = "Ed Mylett",
                AuthorDescription  ="Ed Mylett grew up in Diamond Bar, CA. as the only boy in the family with three younger sisters. His father was his first example of what it takes to succeed in life.",
                BookCoverImageURL = "https://images-na.ssl-images-amazon.com/images/I/41EwHiQzu2L._SX336_BO1,204,203,200_.jpg",
                Categories = "Bussiness Culture",
                ContentDescription = "In The Power of One More, renowned keynote speaker and performance expert Ed Mylett draws on 30 years of experience as an entrepreneur and coach to top athletes, entertainers, and.."  ,              CreatedBy = 1,
                CreatedDate = DateTime.Now,
                PageCount = 600,
                IsDeleted = false,
                Title = "The Power of One More",
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now,
                UUID = Guid.NewGuid().ToString()
                },
                new Book() {Author = "Robert Greene",
                AuthorDescription  = "Robert Greene is the author of the New York Times bestsellers The 48 Laws of Power, The Art of..",
                BookCoverImageURL = "https://images-na.ssl-images-amazon.com/images/I/41EwHiQzu2L._SX336_BO1,204,203,200_.jpg",
                Categories = "Bussiness Culture",
                ContentDescription =  "Amoral, cunning, ruthless, and instructive, this multi-million-copy New York Times bestseller is the definitive manual for anyone interested in gaining, observing, or defending against ultimate control – from the author of The Laws of Human Nature.",
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                PageCount = 600,
                IsDeleted = false,
                Title = "The 48 Laws of Power",
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now,
                UUID = Guid.NewGuid().ToString()
                },
                new Book() {Author = "Amy Odell",
                AuthorDescription  = "Amy Odell is a fashion journalist whose work has appeared in New York magazine, Time, Bloomberg",
                BookCoverImageURL = "https://kbimages1-a.akamaihd.net/Images/4929af70-799a-4e4f-a274-9ed39580a532/255/400/False/image.jpg",
                Categories = "Women & Business",
                ContentDescription ="Bloomberg’s 10 Most Compelling Books to Put on Your Reading List This Spring..",
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                PageCount = 600,
                IsDeleted = false,
                Title = "Anna: The Biography",
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now,
                UUID = Guid.NewGuid().ToString()
                }
            };
        }
    }
}
