using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Queries.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.Handlers
{
    public class FindAllCostumersQueryHandler : IRequestHandler<FindAllCostumersQuery, IList<CustomerDTO>>
    {
        private readonly IApplicationDbContext _context;

        public FindAllCostumersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CustomerDTO>> Handle(FindAllCostumersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Customer> customers = _context.Customers.AsNoTracking();

            if (!string.IsNullOrEmpty(request.Name))
            {
                customers = customers.Where(a => a.Name.Contains(request.Name));
            }

            if (request.GenderId.HasValue)
            {
                customers = customers.Where(a => a.GenderId == request.GenderId);
            }

            if (request.CityId.HasValue)
            {
                customers = customers.Where(a => a.CityId == request.CityId);
            }

            if (request.RegionId.HasValue)
            {
                customers = customers.Where(a => a.RegionId == request.RegionId);
            }

            if (request.ClassificationId.HasValue)
            {
                customers = customers.Where(a => a.ClassificationId == request.ClassificationId);
            }

            if (request.UserId.HasValue)
            {
                customers = customers.Where(a => a.UserId == request.UserId);
            }

            if (request.LastPurchaseStart.HasValue)
            {
                customers = customers.Where(a => a.LastPurchase >=  request.LastPurchaseStart);
            }

            if (request.LastPurchaseEnd.HasValue)
            {
                customers = customers.Where(a => a.LastPurchase <= request.LastPurchaseEnd);
            }

            return await customers
                .Select(a => new CustomerDTO()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Phone = a.Phone,
                    ClassificationName = a.Classification.Name,
                    GenderName = a.Gender.Name,
                    CityName = a.City.Name,
                    RegionName = a.Region.Name,
                    LastPurchase = a.LastPurchase,
                    UserName = a.User.Login
                })
                .ToListAsync();
        }
    }
}
