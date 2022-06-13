using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.Services.Interface
{
    public interface IBookService
    {
        APIResponse<bool> Create(BooksDto book);
        APIResponse<bool> Update(BooksDto book);
        APIResponse<bool> Delete(BooksDto book);
        APIResponse<List<BooksDto>> GetAll();
        APIResponse<BooksDto> GetById(int id);
        APIResponse<BooksDto> GetByUUID(string UUID);
    }
}
