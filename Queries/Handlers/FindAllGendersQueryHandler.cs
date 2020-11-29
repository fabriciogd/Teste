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
    public class FindAllGendersQueryHandler : IRequestHandler<FindAllGendersQuery, IList<GenderDTO>>
    {
        private readonly IRepositoryListQuery<Gender, GenderDTO> _repositoryQuery;

        public FindAllGendersQueryHandler(IRepositoryListQuery<Gender, GenderDTO> repositoryQuery)
        {
            _repositoryQuery = repositoryQuery;
        }

        public async Task<IList<GenderDTO>> Handle(FindAllGendersQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryQuery.GetAll();
        }
    }
}
