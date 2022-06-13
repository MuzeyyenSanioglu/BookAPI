using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.DTOs
{
    public class BooksDto
    {
        public string UUID { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string BookCoverImageURL { get; set; }
        public string Author { get; set; }
        public string Categories { get; set; }
        public string AuthorDescription { get; set; }
        public string ContentDescription { get; set; }
    }
}
