using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        bool Save();
    }
}
