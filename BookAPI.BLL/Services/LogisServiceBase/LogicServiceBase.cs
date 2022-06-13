using AutoMapper;
using BookAPI.DAL.DataAccess;
using BookAPI.DAL.Repository;
using BookAPI.DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.BLL.Services.LogisServiceBase
{
    public abstract class LogicServiceBase<T> where T : class
    {

        protected readonly IUnitOfWork unitofwork;
        protected readonly Repository<T> svc;
        protected readonly IMapper mapper;

        public LogicServiceBase(IUnitOfWork unitOfWork, ContextFactory contextFactory, IMapper mapper)
        {
            this.unitofwork = unitOfWork;
            this.svc = new Repository<T>(contextFactory);
            this.mapper = mapper;
        }

    }
}
