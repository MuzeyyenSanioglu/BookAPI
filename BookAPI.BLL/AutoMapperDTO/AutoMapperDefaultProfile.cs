using AutoMapper;
using BookAPI.BLL.DTOs;
using BookAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.AutoMapperDTO
{
    public class AutoMapperDefaultProfile : Profile
    {
        public AutoMapperDefaultProfile()
        {
            CreateMap<Book,BooksDto>().ReverseMap();
        }
    }
}
