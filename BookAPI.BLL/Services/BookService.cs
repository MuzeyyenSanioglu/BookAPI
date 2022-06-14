using AutoMapper;
using BookAPI.BLL.APIResponse;
using BookAPI.BLL.DTOs;
using BookAPI.BLL.Services.Interface;
using BookAPI.DAL.Entities;
using BookAPI.DAL.Repository;

namespace BookAPI.BLL.Services
{
    public class BookService : IBookService
    {
        public IMapper _mapper;
        public IBookrepository _bookRepository;

        public BookService( IMapper mapper , IBookrepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public APIResponse<BooksDto> Create(BooksDto book)
        {
            APIResponse<BooksDto> result = new APIResponse<BooksDto>();
            var entity = _mapper.Map<Book>(book);
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsDeleted = false;
            entity.CreatedBy = 1;
            entity.UpdatedBy = 1;
            _bookRepository.Add(entity);
            result.SetData(_mapper.Map<BooksDto>(entity));
            return result;
        }

        public APIResponse<bool> Delete(string bookUUId)
        {
            APIResponse<bool> result = new APIResponse<bool>();
            Book book = _bookRepository.GetByUUId(bookUUId);
            var entity = _mapper.Map<Book>(book);
            _bookRepository.Delete(entity);
          
            result.SetSuccessStatus();
            return result;
        }

        public APIResponse<bool> DeleteSoft(string uuid)
        {
            APIResponse<bool> result = new APIResponse<bool>();
            Book book = _bookRepository.GetByUUId(uuid);
            var entity = _mapper.Map<Book>(book);
            entity.IsDeleted = true;
            entity.UpdatedDate = DateTime.Now;
            _bookRepository.DeleteSoft(entity);

            result.SetSuccessStatus();
            return result;
        }

        public APIResponse<List<BooksDto>> GetAll()
        {
           APIResponse<List<BooksDto>> rsult  = new APIResponse<List<BooksDto>>();
           var entity = _bookRepository.GetAll();
            rsult.SetData(_mapper.Map<List<BooksDto>>(entity));
            return rsult;
        }

        public APIResponse<BooksDto> GetById(int id)
        {
            APIResponse<BooksDto> result  = new APIResponse<BooksDto>();
            var entity = _bookRepository.GetAll().Where(x => x.Id == id).SingleOrDefault();
            result.SetData(_mapper.Map<BooksDto>(entity));
            return result;
        }

        public APIResponse<BooksDto> GetByUUID(string UUID)
        {
            APIResponse<BooksDto> result = new APIResponse<BooksDto>();
            var entity = _bookRepository.GetByUUId(UUID);
            result.SetData(_mapper.Map<BooksDto>(entity));
            return result;
        }

        public APIResponse<BooksDto> Update(BooksDto book)
        {
            APIResponse<BooksDto> result = new APIResponse<BooksDto>();
            var entity = _mapper.Map<Book>(book);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = 1;
            _bookRepository.Update(entity);
            result.SetSuccessStatus();
            return result;
        }

       
    }
}
