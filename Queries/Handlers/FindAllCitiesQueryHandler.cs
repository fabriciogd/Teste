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
    public class FindAllCitiesQueryHandler : IRequestHandler<FindAllCitiesQuery, IList<CityDTO>>
    {
        private readonly IApplicationDbContext _context;

        public FindAllCitiesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CityDTO>> Handle(FindAllCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cities.AsNoTracking()
                .Select(a => new CityDTO()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
        }
    }
}
