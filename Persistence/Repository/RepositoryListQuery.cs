using Application.Base;
using Application.Interfaces;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepositoryListQuery<TEntity, TDTO> : IRepositoryListQuery<TEntity, TDTO>
        where TEntity : ListEntity
        where TDTO : ListDTO, new()
    {
        private readonly IApplicationDbContext _context;

        public RepositoryListQuery(IApplicationDbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> Queryable
        {
            get
            {
                return this._context.AsNoTracking<TEntity>();
            }
        }

        public async Task<IList<TDTO>> GetAll()
        {
            var query = this.Queryable;

            return await query.Select(a => new TDTO()
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToListAsync();
        }
    }
}
