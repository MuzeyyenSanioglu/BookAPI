using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using BookAPI.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace BookAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ELKController : ControllerBase
    {
        public IBookElkServices elkServices;

        public ELKController(IBookElkServices elkServices)
        {
            this.elkServices = elkServices;
        }
        [HttpPost]
        public APIResponse ELKBulkInsert([FromBody] List<BooksDto> books)
        {
            APIResponse result = new APIResponse();
            var elkResult = elkServices.InsertBullkIndex(books);
            if (!elkResult.IsSuccessful) 
            {
                result.SetFailureStatus(elkResult.StatusCode,elkResult.StatusMessage);
                return result;
            }
            result.SetSuccessStatus();
            return result;
                
        }
        [HttpPost]
        public APIResponse ELKSearch([FromBody] List<string> keywords)
        {
            return elkServices.Search(keywords);
        }

        [HttpPost]
        public APIResponse ELKInsert([FromBody] BooksDto books)
        {
            return elkServices.InsertIndex(books);

        }
    }
}
