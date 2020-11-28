using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Queries.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.Handlers
{
    public class FindAllRegionsQueryHandler : IRequestHandler<FindAllRegionsQuery, IList<RegionDTO>>
    {
        private readonly IApplicationDbContext _context;

        public FindAllRegionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<RegionDTO>> Handle(FindAllRegionsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Regions.AsNoTracking()
                .Select(a => new RegionDTO()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
        }
    }
}