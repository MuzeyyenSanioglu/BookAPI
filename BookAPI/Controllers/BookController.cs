using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using BookAPI.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
        public IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public APIResponse AddBook([FromBody] BooksDto books)
        {
            return _bookService.Create(books);
        }
        public APIResponse UpdateBook([FromBody] BooksDto books)
        {
            return _bookService.Update(books);
        }
        public APIResponse<List<BooksDto>> GetAllBook()
        {
            return _bookService.GetAll();
        }
    }
}
