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
        [HttpPost]
        public APIResponse AddBook([FromBody] BooksDto books)
        {
            return _bookService.Create(books);
        }
        [HttpPost]
        public APIResponse UpdateBook([FromBody] BooksDto books)
        {
            return _bookService.Update(books);
        }
        [HttpGet]
        public APIResponse<List<BooksDto>> GetAllBook()
        {
            return _bookService.GetAll();
        }
        [HttpDelete]
        public APIResponse<bool> DeleteBook(string uuid)
        {
            return _bookService.Delete(uuid);
        }
        [HttpDelete]
        public APIResponse<bool> SoftDeleteBook(string uuid)
        {
            return _bookService.DeleteSoft(uuid);
        }
    }
}
