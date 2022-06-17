using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.Services.Interface
{
    public interface IBookElkServices
    {
        APIResponse<ElasticClient> Auth();
        APIResponse<BulkResponse> InsertBullkIndex(List<BooksDto>  datas);
        APIResponse<List<BooksDto>> Search(List<string> keywords);
        APIResponse<IndexResponse> InsertIndex(BooksDto data);
    }
}
