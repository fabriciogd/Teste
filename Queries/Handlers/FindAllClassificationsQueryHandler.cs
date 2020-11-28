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
    public class FindAllClassificationsQueryHandler : IRequestHandler<FindAllClassificationsQuery, IList<ClassificationDTO>>
    {
        private readonly IApplicationDbContext _context;

        public FindAllClassificationsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ClassificationDTO>> Handle(FindAllClassificationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Classifications.AsNoTracking()
                .Select(a => new ClassificationDTO()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
        }
    }
}
