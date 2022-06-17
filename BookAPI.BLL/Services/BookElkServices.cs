using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using BookAPI.BLL.Services.Interface;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.Services
{
    public class BookElkServices : IBookElkServices

    {
        public APIResponse<ElasticClient> Auth()
        {
            APIResponse<ElasticClient> resullt = new APIResponse<ElasticClient>();
            ConnectionSettings connSettings = new ConnectionSettings(new Uri("http://localhost:9200/"))
                                                                    .DefaultIndex("esearchitems")
                                                                    .DefaultMappingFor<BooksDto>(m => m
                                                                    .PropertyName(p => p.ContentDescription, "ContentDescription").PropertyName(p => p.Title, "Title"));
            ElasticClient elasticClient = new ElasticClient(connSettings);
            resullt.SetData(elasticClient);
            return resullt;
        }

        public APIResponse<BulkResponse> InsertBullkIndex(List<BooksDto> datas)
        {
            APIResponse<BulkResponse> result = new APIResponse<BulkResponse>();
            ElasticClient elasticClient = Auth().Data;
            if (!elasticClient.Indices.Exists("esearchitems").Exists)
                elasticClient.Indices.Create("esearchitems", index => index.Map<BooksDto>(x => x.AutoMap()));

            BulkResponse response = elasticClient.Bulk(b => b.Index("esearchitems").IndexMany(datas));
            result.SetData(response);
            return result;
        }

        public APIResponse<IndexResponse> InsertIndex(BooksDto data)
        {
            APIResponse<IndexResponse> result = new APIResponse<IndexResponse>();
            ElasticClient elasticClient = Auth().Data;
            if (!elasticClient.Indices.Exists("esearchitems").Exists)
                elasticClient.Indices.Create("esearchitems", index => index.Map<BooksDto>(x => x.AutoMap()));
            IndexResponse response = elasticClient.IndexDocument(data);
            result.SetData(response);
            return result;
        }

        public APIResponse<List<BooksDto>> Search(List<string> keywords)
        {
            APIResponse<List<BooksDto>> result = new APIResponse<List<BooksDto>>();
           
            List<BooksDto> books = new List<BooksDto>();
            foreach (string keyword in keywords)
            {
                ElasticClient elasticClient = Auth().Data;
                var searchResponse = SearchDataIELK(keyword);
                if (searchResponse.Documents.Count() > 0)
                {
                    books = AddKeywordsDatas(searchResponse, books);
                    continue;
                }

            }
            var dataUUID = books.GroupBy(s => s.UUID).Select( g =>new { UUID = g.Key, Count = g.Count() }).Where(s => s.Count >= 3).ToList();
            List<BooksDto> resultData = new List<BooksDto>();
            foreach (var item in dataUUID)
            {
                if (resultData.Any(s => s.UUID == item.UUID))
                    continue;
                BooksDto book = books.Where(s => s.UUID == item.UUID).FirstOrDefault();
                if (book != null)
                 resultData.Add(book);
            }
            result.SetData(resultData);
            return result;
        }   

        #region Utility

        public List<BooksDto> AddKeywordsDatas(ISearchResponse<BooksDto> searchResponse, List<BooksDto> data)
        {
            List<BooksDto> bookData = new List<BooksDto>();
            foreach (BooksDto news in searchResponse.Documents)
            {
                if (bookData.Any(s => s.UUID == news.UUID))
                    continue;
                bookData.Add(news);
            }
            data.AddRange(bookData);
            return data;
        }
        public ISearchResponse<BooksDto> SearchDataIELK(string keyword)
        {
            ElasticClient elasticClient = Auth().Data;

            var searchResponse = elasticClient.Search<BooksDto>(s =>
                    s.Index("esearchitems").From(0).Query(p => p
                    .QueryString(s => s
                    .AnalyzeWildcard()
                    .Query("*" + keyword.ToLower() + "*")
                    .MinimumShouldMatch("100%")
                    .Fields(f => f.Fields(
                        f1 => f1.ContentDescription,
                        f2 => f2.Title
                        )))));
            return searchResponse;
        }
        #endregion
    }
}
