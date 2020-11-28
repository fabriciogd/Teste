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
    public class FindAllUsersQueryHandler : IRequestHandler<FindAllUsersQuery, IList<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public FindAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<UserDTO>> Handle(FindAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking()
                .Select(a => new UserDTO()
                {
                    Id = a.Id,
                    Name = a.Login
                }).ToListAsync();
        }
    }
}
