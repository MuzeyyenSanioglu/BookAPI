using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using BookAPI.BLL.Services.Interface;
using Fleskup.WebApi.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
        [HttpGet]
        public APIResponse<List<GroupCategoryDto>> GetBooksGroupAndCountByCategory()
        {
            APIResponse<List<GroupCategoryDto>> result = new APIResponse<List<GroupCategoryDto>>();
            var categoryResult = _bookService.GetBooksGroupAndCountByCategory();
            if (!categoryResult.IsSuccessful)
            {
                result.SetFailureStatus(categoryResult.StatusCode, categoryResult.StatusMessage);
                return result;
            }

            result.SetData(categoryResult.Data);
            return result;
        }

    }
}
