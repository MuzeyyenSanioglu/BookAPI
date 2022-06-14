using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.Services.Interface
{
    public interface IBookService
    {
        APIResponse<BooksDto> Create(BooksDto book);
        APIResponse<BooksDto> Update(BooksDto book);
        APIResponse<bool> Delete(string book);
        APIResponse<bool> DeleteSoft(string book);
        APIResponse<List<BooksDto>> GetAll();
        APIResponse<BooksDto> GetById(int id);
        APIResponse<BooksDto> GetByUUID(string UUID);
        APIResponse<List<JObject>> GetBooksGroupAndCountByCategory();
    }
}
