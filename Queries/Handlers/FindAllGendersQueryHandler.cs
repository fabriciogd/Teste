using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Queries.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.Handlers
{
    public class FindAllGendersQueryHandler : IRequestHandler<FindAllGendersQuery, IList<GenderDTO>>
    {
        private readonly IApplicationDbContext _context;

        public FindAllGendersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<GenderDTO>> Handle(FindAllGendersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Genders.AsNoTracking()
                .Select(a => new GenderDTO()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
        }
    }
}
