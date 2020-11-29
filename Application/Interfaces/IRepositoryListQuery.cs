using Application.Base;
using Domain.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepositoryListQuery<TEntity, TDTO>
        where TEntity : ListEntity
        where TDTO : ListDTO
    {
        Task<IList<TDTO>> GetAll();
    }
}
