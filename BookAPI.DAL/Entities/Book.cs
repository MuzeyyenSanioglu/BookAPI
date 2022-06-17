using BookAPI.DAL.Entities.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.DAL.Entities
{
    public class Book :EntityBase
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
