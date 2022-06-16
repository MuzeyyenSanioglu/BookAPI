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
            ElasticClient elasticClient= Auth().Data;
            List<BooksDto> books = new List<BooksDto>();
            foreach (string keyword in keywords)
            {
                var searchResponse = elasticClient.Search<BooksDto>( s=>
                s.Index("esearchitems").From(0).Query( p=>
                   p.Match(m=>
                     m.Field(f => f.ContentDescription)
                     .Field(f => f.Title)
                     .Query(keyword))));
                if (searchResponse.Documents.Count() > 0)
                    books.AddRange(searchResponse.Documents);
            }
            result.SetData(books);
            return result;
        }
    }
}
