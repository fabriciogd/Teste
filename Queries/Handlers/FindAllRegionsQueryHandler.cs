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
    public class FindAllRegionsQueryHandler : IRequestHandler<FindAllRegionsQuery, IList<RegionDTO>>
    {
        private readonly IRepositoryListQuery<Region, RegionDTO> _repositoryQuery;

        public FindAllRegionsQueryHandler(IRepositoryListQuery<Region, RegionDTO> repositoryQuery)
        {
            _repositoryQuery = repositoryQuery;
        }

        public async Task<IList<RegionDTO>> Handle(FindAllRegionsQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryQuery.GetAll();
        }
    }
}