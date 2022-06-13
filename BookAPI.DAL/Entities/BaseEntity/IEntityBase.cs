using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.Entities.BaseEntity
{
    public interface IEntityBase
    {
        
        int  Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedDate { get; set; }
        int CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        int UpdatedBy { get; set; }
    }
}
