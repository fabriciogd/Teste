using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using MediatR;
using Queries.Messages;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.Handlers
{
    public class FindAllCitiesQueryHandler : IRequestHandler<FindAllCitiesQuery, IList<CityDTO>>
    {
        private readonly IRepositoryListQuery<City, CityDTO> _repositoryQuery;

        public FindAllCitiesQueryHandler(IRepositoryListQuery<City, CityDTO> repositoryQuery)
        {
            _repositoryQuery = repositoryQuery;
        }

        public async Task<IList<CityDTO>> Handle(FindAllCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryQuery.GetAll();
        }
    }
}
