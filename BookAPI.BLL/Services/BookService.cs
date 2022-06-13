using AutoMapper;
using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using BookAPI.BLL.Services.Interface;
using BookAPI.BLL.Services.LogisServiceBase;
using BookAPI.DAL.DataAccess;
using BookAPI.DAL.Entities;
using BookAPI.DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.Services
{
    public class BookService : LogicServiceBase<Book>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork, ContextFactory contextFactory, IMapper mapper) : base(unitOfWork, contextFactory, mapper)
        {
        }

        public APIResponse<bool> Create(BooksDto book)
        {
            APIResponse<bool> result = new APIResponse<bool>();
            var entity = mapper.Map<Book>(book);
            svc.Add(entity);
            unitofwork.Save();
            result.SetSuccessStatus();
            return result;
        }

        public APIResponse<bool> Delete(BooksDto book)
        {
            APIResponse<bool> result = new APIResponse<bool>();
            var entity = mapper.Map<Book>(book);
            this.svc.Delete(entity);
            unitofwork.Save();
            result.SetSuccessStatus();
            return result;
        }

        public APIResponse<List<BooksDto>> GetAll()
        {
           APIResponse<List<BooksDto>> rsult  = new APIResponse<List<BooksDto>>();
           var entity =  svc.GetAll();
            rsult.SetData(mapper.Map<List<BooksDto>>(entity));
            return rsult;
        }

        public APIResponse<BooksDto> GetById(int id)
        {
            APIResponse<BooksDto> result  = new APIResponse<BooksDto>();
            var entity = svc.GetAll().Where(x => x.Id == id).SingleOrDefault();
            result.SetData(mapper.Map<BooksDto>(entity));
            return result;
        }

        public APIResponse<BooksDto> GetByUUID(string UUID)
        {
            APIResponse<BooksDto> result = new APIResponse<BooksDto>();
            var entity = svc.GetAll().Where(x => x.UUID == UUID).SingleOrDefault();
            result.SetData(mapper.Map<BooksDto>(entity));
            return result;
        }

        public APIResponse<bool> Update(BooksDto book)
        {
            APIResponse<bool> result = new APIResponse<bool>();
            var entity = mapper.Map<Book>(book);
            this.svc.Update(entity);
            unitofwork.Save();
            result.SetSuccessStatus();
            return result;
        }
    }
}
