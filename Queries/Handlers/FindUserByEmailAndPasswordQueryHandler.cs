using Application.Interfaces;
using Commands.Messages;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.Handlers
{
    public class FindUserByEmailAndPasswordQueryHandler : IRequestHandler<FindUserByEmailAndPasswordQuery, User>
    {
        private readonly IApplicationDbContext _context;

        public FindUserByEmailAndPasswordQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(FindUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.Include(a => a.Role).AsNoTracking().FirstOrDefaultAsync(a => a.Email == request.Email && a.Password == request.Password);
        }
    }
}
